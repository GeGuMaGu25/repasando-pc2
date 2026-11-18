using si730pc2u202216448.Api.Heroes.Domain.Model.Aggregates;
using si730pc2u202216448.Api.Heroes.Interfaces.Rest.Resources;

namespace si730pc2u202216448.Api.Heroes.Interfaces.Rest.Transform;

/// <summary>
///     Assembler responsible for transforming a <see cref="Hero" /> domain aggregate into a
///     <see cref="HeroResource" /> for REST representation.
/// </summary>
/// <remarks>
///     Author: Gustavo Alonso Olivares Lao
/// </remarks>
public static class HeroResourceFromEntityAssembler
{
    /// <summary>
    ///     Converts a <see cref="Hero" /> domain aggregate to its <see cref="HeroResource" /> representation.
    /// </summary>
    /// <param name="entity">
    ///     The <see cref="Hero" /> aggregate to convert. Must not be null.
    /// </param>
    /// <returns>
    ///     A <see cref="HeroResource" /> object representing the provided hero.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown if the input <paramref name="entity" /> is null.</exception>
    public static HeroResource ToResourceFromEntity(Hero entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity),
                "Hero entity cannot be null when converting to resource.");
        return new HeroResource(
            entity.Id,
            entity.HeroId.Id,
            entity.RegisterEmailAddress.Address,
            entity.HeroPlace,
            entity.HeroCountry,
            entity.HeroContinent.ToString().ToUpperInvariant(),
            entity.HeroAbility,
            entity.RegisterDateAt);
    }
}
