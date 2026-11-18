using si730pc2u202216448.Api.Heroes.Domain.Model.ValueObjects;
using si730pc2u202216448.Api.Shared.Domain.Model.Events;

namespace si730pc2u202216448.Api.Heroes.Domain.Model.Events;

/// <summary>
///     Domain event raised when a new hero is registered.
/// </summary>
/// <remarks>
///     Author: Gustavo Alonso Olivares Lao
/// </remarks>
/// <param name="HeroId">The identifier of the registered hero.</param>
/// <param name="HeroPlace">The place where the hero is registered.</param>
/// <param name="HeroContinent">The continent where the hero is registered.</param>
public record HeroRegisteredEvent(HeroId HeroId, string HeroPlace, Continent HeroContinent) : IEvent;
