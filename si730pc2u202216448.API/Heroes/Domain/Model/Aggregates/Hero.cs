using si730pc2u202216448.API.Heroes.Domain.Model.Events;
using si730pc2u202216448.API.Heroes.Domain.Model.ValueObjects;
using si730pc2u202216448.API.Shared.Domain.Model.Aggregates.Internal;
using si730pc2u202216448.API.Shared.Domain.Model.ValueObjects;

namespace si730pc2u202216448.API.Heroes.Domain.Model.Aggregates;

/// <summary>
///     Represents the Hero aggregate root within the Heroes Bounded Context.
/// </summary>
/// <remarks>
///     This class encapsulates the core data and behavior of a registered hero. Author: Gustavo Alonso Olivares Lao
/// </remarks>
public partial class Hero : AggregateRoot
{
    /// <summary>
    ///     The maximum length allowed for the hero place.
    /// </summary>
    public const int HeroPlaceMaxLength = 50;

    /// <summary>
    ///     The maximum length allowed for the hero country.
    /// </summary>
    public const int HeroCountryMaxLength = 250;

    /// <summary>
    ///     The maximum length allowed for the hero ability.
    /// </summary>
    public const int HeroAbilityMaxLength = 50;

    /// <summary>
    ///     Initializes a new instance of the <see cref="Hero" /> aggregate with default values.
    ///     This constructor is primarily for persistence mechanisms.
    /// </summary>
    public Hero()
    {
        HeroId = null!; // Materialized by the persistence mechanism
        RegisterEmailAddress = null!; // Materialized by the persistence mechanism
        HeroPlace = string.Empty;
        HeroCountry = string.Empty;
        HeroAbility = string.Empty;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Hero" /> aggregate.
    /// </summary>
    /// <param name="heroId">
    ///     The <see cref="HeroId" /> that identifies the hero in another bounded context.
    /// </param>
    /// <param name="registerEmailAddress">
    ///     The <see cref="EmailAddress" /> of the owner that registers the hero.
    /// </param>
    /// <param name="heroPlace">
    ///     The place of the hero. It must not be blank and must not exceed 50 characters.
    /// </param>
    /// <param name="heroCountry">
    ///     The country of the hero. It must not be blank and must not exceed 250 characters.
    /// </param>
    /// <param name="heroContinent">
    ///     The <see cref="Continent" /> of the hero.
    /// </param>
    /// <param name="heroAbility">
    ///     The ability of the hero. It must not be blank and must not exceed 50 characters.
    /// </param>
    /// <exception cref="ArgumentException">Thrown when any value does not satisfy the business rules.</exception>
    public Hero(HeroId heroId, EmailAddress registerEmailAddress, string? heroPlace, string? heroCountry,
        Continent heroContinent, string? heroAbility)
    {
        ArgumentNullException.ThrowIfNull(heroId);
        ArgumentNullException.ThrowIfNull(registerEmailAddress);
        if (!Enum.IsDefined(heroContinent))
            throw new ArgumentOutOfRangeException(nameof(heroContinent), heroContinent,
                "The hero continent must be a value between 1 and 5.");
        HeroId = heroId;
        RegisterEmailAddress = registerEmailAddress;
        HeroPlace = ValidateText(heroPlace, HeroPlaceMaxLength, nameof(heroPlace));
        HeroCountry = ValidateText(heroCountry, HeroCountryMaxLength, nameof(heroCountry));
        HeroContinent = heroContinent;
        HeroAbility = ValidateText(heroAbility, HeroAbilityMaxLength, nameof(heroAbility));
        RegisterDateAt = DateTime.UtcNow;
        AddDomainEvent(new HeroRegisteredEvent(HeroId, HeroPlace, HeroContinent));
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Hero" /> aggregate using primitive values.
    /// </summary>
    /// <param name="heroId">The identifier of the hero in another bounded context.</param>
    /// <param name="registerEmailAddress">The email address of the owner that registers the hero.</param>
    /// <param name="heroPlace">The place of the hero.</param>
    /// <param name="heroCountry">The country of the hero.</param>
    /// <param name="heroContinent">The <see cref="Continent" /> of the hero.</param>
    /// <param name="heroAbility">The ability of the hero.</param>
    /// <exception cref="ArgumentException">Thrown when any value does not satisfy the business rules.</exception>
    public Hero(long heroId, string? registerEmailAddress, string? heroPlace, string? heroCountry,
        Continent heroContinent, string? heroAbility)
        : this(new HeroId(heroId), new EmailAddress(registerEmailAddress), heroPlace, heroCountry, heroContinent,
            heroAbility)
    {
    }

    /// <summary>
    ///     Gets the unique identifier of the hero registration.
    /// </summary>
    public long Id { get; }

    /// <summary>
    ///     Gets the <see cref="HeroId" /> that identifies the hero in another bounded context.
    /// </summary>
    public HeroId HeroId { get; private set; }

    /// <summary>
    ///     Gets the <see cref="EmailAddress" /> of the owner that registered the hero.
    /// </summary>
    public EmailAddress RegisterEmailAddress { get; private set; }

    /// <summary>
    ///     Gets the place of the hero.
    /// </summary>
    public string HeroPlace { get; private set; }

    /// <summary>
    ///     Gets the country of the hero.
    /// </summary>
    public string HeroCountry { get; private set; }

    /// <summary>
    ///     Gets the <see cref="Continent" /> of the hero.
    /// </summary>
    public Continent HeroContinent { get; private set; }

    /// <summary>
    ///     Gets the ability of the hero.
    /// </summary>
    public string HeroAbility { get; private set; }

    /// <summary>
    ///     Gets the date and time when the hero was registered.
    /// </summary>
    public DateTime RegisterDateAt { get; private set; }

    /// <summary>
    ///     Validates that a text value is not blank and does not exceed a maximum length.
    /// </summary>
    /// <param name="value">The text value to validate.</param>
    /// <param name="maxLength">The maximum length allowed.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <returns>The validated text value.</returns>
    /// <exception cref="ArgumentException">Thrown when the value is blank or exceeds the maximum length.</exception>
    private static string ValidateText(string? value, int maxLength, string paramName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value, paramName);
        if (value.Length > maxLength)
            throw new ArgumentException($"The value must not exceed {maxLength} characters.", paramName);
        return value;
    }
}
