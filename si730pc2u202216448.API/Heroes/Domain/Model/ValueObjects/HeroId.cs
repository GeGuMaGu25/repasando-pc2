namespace si730pc2u202216448.API.Heroes.Domain.Model.ValueObjects;

/// <summary>
///     Value object that identifies a hero in another bounded context.
/// </summary>
/// <remarks>
///     Author: Gustavo Alonso Olivares Lao
/// </remarks>
public record HeroId
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="HeroId" /> value object.
    /// </summary>
    /// <param name="id">
    ///     The identifier of the hero. It must be greater than zero.
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Thrown when <paramref name="id" /> is less than or equal to zero.
    /// </exception>
    public HeroId(long id)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id), id, "The hero id must be greater than zero.");
        Id = id;
    }

    /// <summary>
    ///     Gets the identifier of the hero.
    /// </summary>
    public long Id { get; }

    public override string ToString() => Id.ToString();
}
