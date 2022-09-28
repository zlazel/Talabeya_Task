using Talabeya_Task.Application.Common.Models;
using Talabeya_Task.Application.Tickets.Queries.GetTicketsWithPagination;
using Talabeya_Task.Domain.Entities;

namespace Talabeya_Task.Infrastructure.Persistence.Data;

public interface ITicketRepository
{
    Task<int> AddAsync(Ticket entity, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
    Task<PaginatedList<TicketBriefDto>> GetPaginatedListAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task HandleTicketAsync(int id, CancellationToken cancellationToken);
}