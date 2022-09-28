using Talabeya_Task.Application.Common.Exceptions;
using Talabeya_Task.Application.Common.Interfaces;
using Talabeya_Task.Domain.Entities;
using MediatR;
using Talabeya_Task.Domain.Enums;
using Talabeya_Task.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Talabeya_Task.Application.Tickets.Commands.UpdateTicket;

public record HandleTicketCommand(int Id) : IRequest;
public class UpdateTicketCommandHandler : IRequestHandler<HandleTicketCommand>
{
    private readonly ITicketRepository _ticketRepository;

    public UpdateTicketCommandHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<Unit> Handle(HandleTicketCommand request, CancellationToken cancellationToken)
    {
        await _ticketRepository.HandleTicketAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}
