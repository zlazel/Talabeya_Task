using AutoMapper;
using AutoMapper.QueryableExtensions;
using Talabeya_Task.Application.Common.Interfaces;
using Talabeya_Task.Application.Common.Mappings;
using Talabeya_Task.Application.Common.Models;
using MediatR;
using Talabeya_Task.Domain.Events;
using Talabeya_Task.Application.Tickets.Commands.UpdateTicket;
using Talabeya_Task.Infrastructure.Persistence.Data;

namespace Talabeya_Task.Application.Tickets.Queries.GetTicketsWithPagination;

public record GetTicketsWithPaginationQuery : IRequest<PaginatedList<TicketBriefDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetTicketsWithPaginationQueryHandler : IRequestHandler<GetTicketsWithPaginationQuery, PaginatedList<TicketBriefDto>>
{
    private readonly IMediator _mediator;
    private readonly ITicketRepository _ticketRepository;

    public GetTicketsWithPaginationQueryHandler(IMediator mediator, ITicketRepository ticketRepository)
    {
        _mediator = mediator;
        _ticketRepository = ticketRepository;
    }

    public async Task<PaginatedList<TicketBriefDto>> Handle(GetTicketsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        await _mediator.Publish(new TicketHandleNeededEvent(), cancellationToken);

        return await _ticketRepository.GetPaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
    }
}
