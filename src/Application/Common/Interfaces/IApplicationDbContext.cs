using Talabeya_Task.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Talabeya_Task.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Ticket> Tickets { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
