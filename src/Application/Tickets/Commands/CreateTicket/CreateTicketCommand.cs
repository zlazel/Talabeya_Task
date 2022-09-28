using Talabeya_Task.Application.Common.Interfaces;
using Talabeya_Task.Domain.Entities;
using Talabeya_Task.Domain.Events;
using MediatR;
using Talabeya_Task.Domain.Enums;
using Talabeya_Task.Infrastructure.Persistence.Data;

namespace Talabeya_Task.Application.Tickets.Commands.CreateTicket;

public record CreateTicketCommand : IRequest<int>
{
    public string? Phone { get; init; }
    public int Goverenorate { get; set; }
    public int City { get; set; }
    public int District { get; set; }
}

public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, int>
{
    private readonly ITicketRepository _ticketRepository;

    public CreateTicketCommandHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<int> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var entity = new Ticket
        {
            Phone = request.Phone,
            Goverenorate = (Goverenorate)request.Goverenorate,
            City = (City)request.City,
            District = (District)request.District,
        };
        return await _ticketRepository.AddAsync(entity, cancellationToken);
    }
}
