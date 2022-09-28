using Talabeya_Task.Application.Common.Exceptions;
using Talabeya_Task.Application.Common.Interfaces;
using Talabeya_Task.Domain.Entities;
using Talabeya_Task.Domain.Events;
using MediatR;

namespace Talabeya_Task.Application.Tickets.Commands.DeleteTicket;

public record DeleteTicketCommand(int Id) : IRequest;

public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteTicketCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Tickets
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Ticket), request.Id);
        }

        _context.Tickets.Remove(entity);

        entity.AddDomainEvent(new TicketDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
