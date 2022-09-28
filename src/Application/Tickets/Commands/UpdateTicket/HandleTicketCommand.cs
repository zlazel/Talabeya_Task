using Talabeya_Task.Application.Common.Exceptions;
using Talabeya_Task.Application.Common.Interfaces;
using Talabeya_Task.Domain.Entities;
using MediatR;
using Talabeya_Task.Domain.Enums;

namespace Talabeya_Task.Application.Tickets.Commands.UpdateTicket;

public record HandleTicketCommand(int Id) : IRequest;
public class UpdateTicketCommandHandler : IRequestHandler<HandleTicketCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateTicketCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(HandleTicketCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Tickets
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Ticket), request.Id);
        }

        entity.IsHandeled = true;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
