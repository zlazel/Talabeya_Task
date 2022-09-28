using AutoMapper;
using AutoMapper.QueryableExtensions;
using Talabeya_Task.Application.Common.Interfaces;
using Talabeya_Task.Application.Common.Mappings;
using Talabeya_Task.Application.Common.Models;
using MediatR;
using Talabeya_Task.Domain.Events;
using Talabeya_Task.Application.Tickets.Commands.UpdateTicket;

namespace Talabeya_Task.Application.Tickets.Queries.GetTicketsWithPagination;

public record GetTicketsWithPaginationQuery : IRequest<PaginatedList<TicketBriefDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetTicketsWithPaginationQueryHandler : IRequestHandler<GetTicketsWithPaginationQuery, PaginatedList<TicketBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public GetTicketsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper, IMediator mediator)
    {
        _context = context;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<PaginatedList<TicketBriefDto>> Handle(GetTicketsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        await _mediator.Publish(new TicketHandleNeededEvent(), cancellationToken);
        var list = await _context.Tickets
        .OrderByDescending(x => x.Created)
        .ProjectTo<TicketBriefDto>(_mapper.ConfigurationProvider)
        .PaginatedListAsync(request.PageNumber, request.PageSize);
        return list;
    }
}
