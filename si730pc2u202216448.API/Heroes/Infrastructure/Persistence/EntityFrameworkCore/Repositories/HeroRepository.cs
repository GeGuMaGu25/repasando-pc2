using si730pc2u202216448.API.Heroes.Domain.Model.Aggregates;
using si730pc2u202216448.API.Heroes.Domain.Model.ValueObjects;
using si730pc2u202216448.API.Heroes.Domain.Repositories;
using si730pc2u202216448.API.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using si730pc2u202216448.API.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace si730pc2u202216448.API.Heroes.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

/// <summary>
///     Represents the hero repository in the SuperHero Platform.
/// </summary>
/// <remarks>
///     Author: Gustavo Alonso Olivares Lao
/// </remarks>
/// <param name="context">
///     The <see cref="AppDbContext" /> to use.
/// </param>
public class HeroRepository(AppDbContext context) : BaseRepository<Hero>(context), IHeroRepository
{
    /// <inheritdoc />
    public async Task<bool> ExistsByHeroIdAndHeroPlaceAndHeroCountryAndHeroContinentAsync(HeroId heroId,
        string heroPlace, string heroCountry, Continent heroContinent, CancellationToken cancellationToken)
    {
        return await Context.Set<Hero>().AnyAsync(hero =>
                hero.HeroId == heroId &&
                hero.HeroPlace == heroPlace &&
                hero.HeroCountry == heroCountry &&
                hero.HeroContinent == heroContinent,
            cancellationToken);
    }
}
