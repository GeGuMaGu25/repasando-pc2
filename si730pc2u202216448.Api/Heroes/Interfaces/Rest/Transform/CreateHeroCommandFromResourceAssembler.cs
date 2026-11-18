using si730pc2u202216448.Api.Heroes.Domain.Model.Commands;
using si730pc2u202216448.Api.Heroes.Interfaces.Rest.Resources;

namespace si730pc2u202216448.Api.Heroes.Interfaces.Rest.Transform;

/// <summary>
///     Assembler responsible for transforming a <see cref="CreateHeroResource" /> into a
///     <see cref="CreateHeroCommand" />.
/// </summary>
/// <remarks>
///     Author: Gustavo Alonso Olivares Lao
/// </remarks>
public static class CreateHeroCommandFromResourceAssembler
{
    /// <summary>
    ///     Converts a <see cref="CreateHeroResource" /> to a <see cref="CreateHeroCommand" />.
    /// </summary>
    /// <param name="resource">
    ///     The <see cref="CreateHeroResource" /> containing the data for creating a hero. Must not be null.
    /// </param>
    /// <param name="heroId">
    ///     The identifier of the hero, taken from the request path.
    /// </param>
    /// <returns>
    ///     A new <see cref="CreateHeroCommand" /> instance.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown if the input <paramref name="resource" /> is null.</exception>
    public static CreateHeroCommand ToCommandFromResource(CreateHeroResource resource, long heroId)
    {
        if (resource == null)
            throw new ArgumentNullException(nameof(resource),
                "CreateHeroResource cannot be null when converting to command.");
        return new CreateHeroCommand(
            heroId,
            resource.RegisterEmailAddress,
            resource.HeroPlace,
            resource.HeroCountry,
            resource.HeroContinent,
            resource.HeroAbility
        );
    }
}
