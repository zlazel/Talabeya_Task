using Talabeya_Task.Application.Common.Interfaces;
using Talabeya_Task.Domain.Entities;
using Talabeya_Task.Domain.Events;
using MediatR;
using Talabeya_Task.Domain.Enums;

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
    private readonly IApplicationDbContext _context;

    public CreateTicketCommandHandler(IApplicationDbContext context)
    {
        _context = context;
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

        entity.AddDomainEvent(new TicketCreatedEvent(entity));

        _context.Tickets.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
