using si730pc2u202216448.Api.Heroes.Domain.Model;
using si730pc2u202216448.Api.Heroes.Domain.Model.Aggregates;
using si730pc2u202216448.Api.Resources.Errors;
using si730pc2u202216448.Api.Shared.Application.Model;
using si730pc2u202216448.Api.Shared.Interfaces.Rest.ProblemDetails;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace si730pc2u202216448.Api.Heroes.Interfaces.Rest.Transform;

/// <summary>
///     Assembler responsible for transforming Heroes results into HTTP action results.
/// </summary>
/// <remarks>
///     Author: Gustavo Alonso Olivares Lao
/// </remarks>
public static class HeroesActionResultAssembler
{
    // --- Helper for transforming HeroesError to StatusCode ---
    private static int ToStatusCodeFromHeroesError(HeroesError error)
    {
        return error switch
        {
            HeroesError.HeroNotFound => StatusCodes.Status404NotFound,
            HeroesError.DuplicateHero => StatusCodes.Status409Conflict,
            HeroesError.InvalidHeroId => StatusCodes.Status400BadRequest,
            HeroesError.InvalidRegisterEmailAddress => StatusCodes.Status400BadRequest,
            HeroesError.InvalidHeroPlace => StatusCodes.Status400BadRequest,
            HeroesError.InvalidHeroCountry => StatusCodes.Status400BadRequest,
            HeroesError.InvalidHeroContinent => StatusCodes.Status400BadRequest,
            HeroesError.InvalidHeroAbility => StatusCodes.Status400BadRequest,
            HeroesError.OperationCancelled => StatusCodes.Status409Conflict,
            HeroesError.DatabaseError => StatusCodes.Status500InternalServerError,
            HeroesError.InternalServerError => StatusCodes.Status500InternalServerError,
            _ => StatusCodes.Status400BadRequest // Default
        };
    }

    // --- Specific Assembler Methods ---

    /// <summary>
    ///     Converts the result of the create hero command into an action result.
    /// </summary>
    /// <param name="controller">The controller that handles the request.</param>
    /// <param name="result">The <see cref="Result{T}" /> of the create hero command.</param>
    /// <param name="errorLocalizer">The localizer for error messages.</param>
    /// <param name="problemDetailsFactory">The factory to create problem details responses.</param>
    /// <param name="successAction">The action to execute when the result is successful.</param>
    /// <returns>The <see cref="IActionResult" /> for the request.</returns>
    public static IActionResult ToActionResultFromCreateHeroResult(
        ControllerBase controller,
        Result<Hero> result,
        IStringLocalizer<ErrorMessages> errorLocalizer,
        ProblemDetailsFactory problemDetailsFactory,
        Func<Hero, IActionResult> successAction)
    {
        if (result.IsSuccess) return successAction(result.Value!);

        var error = (HeroesError)result.Error!;
        var statusCode = ToStatusCodeFromHeroesError(error);
        // Localized message according to the Accept-Language header, falling back to the domain message
        var localizedMessage = errorLocalizer[$"{nameof(HeroesError)}.{error}"];
        var message = localizedMessage.ResourceNotFound ? result.Message : localizedMessage.Value;
        return problemDetailsFactory.CreateProblemDetails(controller, statusCode, result.Error, message);
    }
}
