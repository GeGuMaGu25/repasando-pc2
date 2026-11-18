using si730pc2u202216448.API.Shared.Domain.Repositories;
using si730pc2u202216448.API.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;

namespace si730pc2u202216448.API.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

/// <summary>
///     Unit of work for the application.
/// </summary>
/// <remarks>
///     This class is used to save changes to the database context.
///     It implements the IUnitOfWork interface.
/// </remarks>
/// <param name="context">
///     The database context for the application
/// </param>
public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    // inheritedDoc
    public async Task CompleteAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}