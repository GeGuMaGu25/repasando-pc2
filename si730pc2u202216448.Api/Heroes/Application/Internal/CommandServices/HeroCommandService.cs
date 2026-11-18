using si730pc2u202216448.Api.Heroes.Application.CommandServices;
using si730pc2u202216448.Api.Heroes.Domain.Model;
using si730pc2u202216448.Api.Heroes.Domain.Model.Aggregates;
using si730pc2u202216448.Api.Heroes.Domain.Model.Commands;
using si730pc2u202216448.Api.Heroes.Domain.Model.Errors;
using si730pc2u202216448.Api.Heroes.Domain.Model.ValueObjects;
using si730pc2u202216448.Api.Heroes.Domain.Repositories;
using si730pc2u202216448.Api.Shared.Application.Model;
using si730pc2u202216448.Api.Shared.Domain.Model.Errors;
using si730pc2u202216448.Api.Shared.Domain.Repositories;

namespace si730pc2u202216448.Api.Heroes.Application.Internal.CommandServices;

/// <summary>
///     Represents the hero command service in the SuperHero Platform.
/// </summary>
/// <remarks>
///     Author: Gustavo Alonso Olivares Lao
/// </remarks>
/// <param name="heroRepository">
///     The <see cref="IHeroRepository" /> to use.
/// </param>
/// <param name="unitOfWork">
///     The <see cref="IUnitOfWork" /> to use.
/// </param>
public class HeroCommandService(
    IHeroRepository heroRepository,
    IUnitOfWork unitOfWork)
    : IHeroCommandService
{
    /// <inheritdoc />
    public async Task<Result<Hero>> Handle(CreateHeroCommand command, CancellationToken cancellationToken)
    {
        if (!TryParseContinent(command.HeroContinent, out var heroContinent))
            return Result<Hero>.Failure(HeroesErrors.InvalidHeroContinent, HeroesError.InvalidHeroContinent);

        Hero hero;
        try
        {
            hero = new Hero(command.HeroId, command.RegisterEmailAddress, command.HeroPlace, command.HeroCountry,
                heroContinent, command.HeroAbility);
        }
        catch (ArgumentException exception)
        {
            var (error, errorEnum) = ToErrorFromArgumentException(exception);
            return Result<Hero>.Failure(error, errorEnum);
        }

        if (await heroRepository.ExistsByHeroIdAndHeroPlaceAndHeroCountryAndHeroContinentAsync(hero.HeroId,
                hero.HeroPlace, hero.HeroCountry, hero.HeroContinent, cancellationToken))
            return Result<Hero>.Failure(HeroesErrors.DuplicateHero, HeroesError.DuplicateHero);

        await heroRepository.AddAsync(hero, cancellationToken);
        await unitOfWork.CompleteAsync(cancellationToken);

        // Return the created hero
        return Result<Hero>.Success(hero);
    }

    /// <summary>
    ///     Converts the continent name into a <see cref="Continent" />.
    /// </summary>
    /// <param name="continentName">The continent name to convert. Numeric values are not accepted.</param>
    /// <param name="continent">The resulting <see cref="Continent" />.</param>
    /// <returns><c>true</c> if the name matches one of the existing continents; otherwise, <c>false</c>.</returns>
    private static bool TryParseContinent(string? continentName, out Continent continent)
    {
        continent = default;
        var name = Enum.GetNames<Continent>()
            .FirstOrDefault(n => string.Equals(n, continentName?.Trim(), StringComparison.OrdinalIgnoreCase));
        return name != null && Enum.TryParse(name, out continent);
    }

    /// <summary>
    ///     Maps an <see cref="ArgumentException" /> raised by the domain to its Heroes error.
    /// </summary>
    /// <param name="exception">The exception raised by the domain.</param>
    /// <returns>The domain <see cref="Error" /> and the <see cref="HeroesError" /> that correspond.</returns>
    private static (Error error, HeroesError errorEnum) ToErrorFromArgumentException(ArgumentException exception)
    {
        return exception.ParamName switch
        {
            "id" => (HeroesErrors.InvalidHeroId, HeroesError.InvalidHeroId),
            "address" => (HeroesErrors.InvalidRegisterEmailAddress, HeroesError.InvalidRegisterEmailAddress),
            "heroPlace" => (HeroesErrors.InvalidHeroPlace, HeroesError.InvalidHeroPlace),
            "heroCountry" => (HeroesErrors.InvalidHeroCountry, HeroesError.InvalidHeroCountry),
            "heroContinent" => (HeroesErrors.InvalidHeroContinent, HeroesError.InvalidHeroContinent),
            "heroAbility" => (HeroesErrors.InvalidHeroAbility, HeroesError.InvalidHeroAbility),
            _ => (Error.Validation("Heroes.InvalidHeroData", exception.Message), HeroesError.None)
        };
    }
}
