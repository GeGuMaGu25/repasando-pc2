using si730pc2u202216448.Api.Shared.Domain.Model.Entities;

namespace si730pc2u202216448.Api.Heroes.Domain.Model.Aggregates;

/// <summary>
///     Partial class for the <see cref="Hero" /> aggregate, focusing on audit timestamps.
/// </summary>
/// <remarks>
///     Author: Gustavo Alonso Olivares Lao
/// </remarks>
public partial class Hero : IAuditableEntity
{
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}
