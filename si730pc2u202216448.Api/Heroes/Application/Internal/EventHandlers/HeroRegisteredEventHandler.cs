using si730pc2u202216448.Api.Heroes.Domain.Model.Events;
using si730pc2u202216448.Api.Shared.Application.Internal.EventHandlers;

namespace si730pc2u202216448.Api.Heroes.Application.Internal.EventHandlers;

/// <summary>
///     Event handler for <see cref="HeroRegisteredEvent" />.
/// </summary>
/// <remarks>
///     Author: Gustavo Alonso Olivares Lao
/// </remarks>
public class HeroRegisteredEventHandler(ILogger<HeroRegisteredEventHandler> logger)
    : IEventHandler<HeroRegisteredEvent>
{
    /// <inheritdoc />
    public Task Handle(HeroRegisteredEvent domainEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation("Hero registered: Hero {HeroId} in {HeroPlace} ({HeroContinent})",
            domainEvent.HeroId.Id, domainEvent.HeroPlace, domainEvent.HeroContinent);

        return Task.CompletedTask;
    }
}
