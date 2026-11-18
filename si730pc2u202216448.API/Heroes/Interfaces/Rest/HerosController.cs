using System.Net.Mime;
using si730pc2u202216448.API.Heroes.Application.CommandServices;
using si730pc2u202216448.API.Heroes.Interfaces.Rest.Resources;
using si730pc2u202216448.API.Heroes.Interfaces.Rest.Transform;
using si730pc2u202216448.API.Resources.Errors;
using si730pc2u202216448.API.Shared.Interfaces.Rest.ProblemDetails;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace si730pc2u202216448.API.Heroes.Interfaces.Rest;

/// <summary>
///     REST controller that exposes the hero endpoints.
/// </summary>
/// <remarks>
///     Author: Gustavo Alonso Olivares Lao
/// </remarks>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Available Hero Endpoints.")]
public class HerosController(
    IHeroCommandService heroCommandService,
    IStringLocalizer<ErrorMessages> errorLocalizer,
    ProblemDetailsFactory problemDetailsFactory)
    : ControllerBase
{
    private readonly IStringLocalizer<ErrorMessages> _errorLocalizer = errorLocalizer;
    private readonly ProblemDetailsFactory _problemDetailsFactory = problemDetailsFactory;

    /// <summary>
    ///     Registers a new hero
    /// </summary>
    /// <param name="heroId">
    ///     The identifier of the hero, greater than zero
    /// </param>
    /// <param name="resource">
    ///     The <see cref="CreateHeroResource" /> with the hero information
    /// </param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    ///     The created <see cref="HeroResource" /> hero, including its generated id
    /// </returns>
    [HttpPost("{heroId:long}")]
    [EndpointSummary("Register a new hero")]
    [EndpointDescription(
        "Registers a new hero for the hero id specified in the path. The continent must be one of AMERICAN, " +
        "EUROPE, AFRICA, ASIA or OCEANIA. The same hero cannot be registered twice in the same place, " +
        "country and continent.")]
    [ProducesResponseType(typeof(HeroResource), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> CreateHero([FromRoute] long heroId, [FromBody] CreateHeroResource resource,
        CancellationToken cancellationToken)
    {
        var createHeroCommand = CreateHeroCommandFromResourceAssembler.ToCommandFromResource(resource, heroId);
        var result = await heroCommandService.Handle(createHeroCommand, cancellationToken);

        return HeroesActionResultAssembler.ToActionResultFromCreateHeroResult(
            this,
            result,
            _errorLocalizer,
            _problemDetailsFactory,
            createdHero => StatusCode(StatusCodes.Status201Created,
                HeroResourceFromEntityAssembler.ToResourceFromEntity(createdHero))
        );
    }
}
