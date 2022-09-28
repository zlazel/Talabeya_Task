using Talabeya_Task.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Talabeya_Task.Application.Tickets.EventHandlers;

public class TicketCreatedEventHandler : INotificationHandler<TicketCreatedEvent>
{
    private readonly ILogger<TicketCreatedEventHandler> _logger;

    public TicketCreatedEventHandler(ILogger<TicketCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TicketCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Talabeya_Task Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
