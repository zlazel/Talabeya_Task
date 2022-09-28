using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Talabeya_Task.Application.Common.Exceptions;
using Talabeya_Task.Application.Common.Interfaces;
using Talabeya_Task.Application.Common.Mappings;
using Talabeya_Task.Application.Common.Models;
using Talabeya_Task.Application.Tickets.Queries.GetTicketsWithPagination;
using Talabeya_Task.Domain.Entities;
using Talabeya_Task.Domain.Events;

namespace Talabeya_Task.Infrastructure.Persistence.Data;
public class TicketRepository : ITicketRepository
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public TicketRepository(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<int> AddAsync(Ticket entity, CancellationToken cancellationToken)
    {
        await _context.Tickets.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        entity.AddDomainEvent(new TicketCreatedEvent(entity));
        return entity.Id;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await _context.Tickets
            .FindAsync(new object[] { id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Ticket), id);
        }
        _context.Tickets.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
        
        entity.AddDomainEvent(new TicketDeletedEvent(entity));
    }

    public async Task<PaginatedList<TicketBriefDto>> GetPaginatedListAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        return await _context.Tickets
        .OrderByDescending(x => x.Created)
        .ProjectTo<TicketBriefDto>(_mapper.ConfigurationProvider)
        .PaginatedListAsync(pageNumber, pageSize);
    }

    public async Task HandleTicketAsync(int id, CancellationToken cancellationToken)
    {

        var entity = await _context.Tickets
       .FindAsync(new object[] { id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Ticket), id);
        }
        entity.IsHandeled = true;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
