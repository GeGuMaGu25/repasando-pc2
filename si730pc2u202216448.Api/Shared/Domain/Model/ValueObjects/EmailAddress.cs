using System.Net.Mail;

namespace si730pc2u202216448.Api.Shared.Domain.Model.ValueObjects;

/// <summary>
///     Email address value object, common type that can be used by any bounded context.
/// </summary>
/// <remarks>
///     Author: Gustavo Alonso Olivares Lao
/// </remarks>
public record EmailAddress
{
    /// <summary>
    ///     The maximum length allowed for an email address.
    /// </summary>
    public const int MaxLength = 50;

    /// <summary>
    ///     Initializes a new instance of the <see cref="EmailAddress" /> value object.
    /// </summary>
    /// <param name="address">
    ///     The email address. It must be a valid, non-blank email address of up to 50 characters.
    /// </param>
    /// <exception cref="ArgumentException">
    ///     Thrown when <paramref name="address" /> is blank, longer than 50 characters or not a valid email address.
    /// </exception>
    public EmailAddress(string? address)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(address);
        if (address.Length > MaxLength)
            throw new ArgumentException($"The email address must not exceed {MaxLength} characters.",
                nameof(address));
        if (!MailAddress.TryCreate(address, out var mailAddress) || mailAddress.Address != address)
            throw new ArgumentException("The email address is not valid.", nameof(address));
        Address = address;
    }

    /// <summary>
    ///     Gets the email address.
    /// </summary>
    public string Address { get; }

    public override string ToString() => Address;
}
