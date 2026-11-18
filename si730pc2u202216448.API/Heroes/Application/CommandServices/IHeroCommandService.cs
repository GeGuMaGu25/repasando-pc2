using si730pc2u202216448.API.Heroes.Domain.Model.Aggregates;
using si730pc2u202216448.API.Heroes.Domain.Model.Commands;
using si730pc2u202216448.API.Shared.Application.Model;

namespace si730pc2u202216448.API.Heroes.Application.CommandServices;

/// <summary>
///     Represents the hero command service in the SuperHero Platform.
/// </summary>
/// <remarks>
///     Author: Gustavo Alonso Olivares Lao
/// </remarks>
public interface IHeroCommandService
{
    /// <summary>
    ///     Handles the create hero command in the SuperHero Platform.
    /// </summary>
    /// <param name="command">
    ///     The <see cref="CreateHeroCommand" /> command to handle.
    /// </param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     A <see cref="Result{T}" /> with the created <see cref="Hero" /> or the error found.
    /// </returns>
    Task<Result<Hero>> Handle(CreateHeroCommand command, CancellationToken cancellationToken);
}
