using si730pc2u202216448.Api.Heroes.Domain.Model.Aggregates;
using si730pc2u202216448.Api.Heroes.Domain.Model.ValueObjects;
using si730pc2u202216448.Api.Shared.Domain.Repositories;

namespace si730pc2u202216448.Api.Heroes.Domain.Repositories;

/// <summary>
///     Represents the hero repository in the SuperHero Platform.
/// </summary>
/// <remarks>
///     Author: Gustavo Alonso Olivares Lao
/// </remarks>
public interface IHeroRepository : IBaseRepository<Hero>
{
    /// <summary>
    ///     Checks whether a hero is already registered with the same hero id, place, country and continent.
    /// </summary>
    /// <param name="heroId">The <see cref="HeroId" /> to search for.</param>
    /// <param name="heroPlace">The place to search for.</param>
    /// <param name="heroCountry">The country to search for.</param>
    /// <param name="heroContinent">The <see cref="Continent" /> to search for.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     <c>true</c> if a hero with the same values exists; otherwise, <c>false</c>.
    /// </returns>
    Task<bool> ExistsByHeroIdAndHeroPlaceAndHeroCountryAndHeroContinentAsync(HeroId heroId, string heroPlace,
        string heroCountry, Continent heroContinent, CancellationToken cancellationToken);
}
