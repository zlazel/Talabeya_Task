using Talabeya_Task.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Talabeya_Task.Application.Tickets.EventHandlers;

public class TicketCompletedEventHandler : INotificationHandler<TicketCompletedEvent>
{
    private readonly ILogger<TicketCompletedEventHandler> _logger;

    public TicketCompletedEventHandler(ILogger<TicketCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TicketCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Talabeya_Task Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
