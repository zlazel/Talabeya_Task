using Talabeya_Task.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using Talabeya_Task.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Talabeya_Task.Domain.Entities;
using System.Linq;

namespace Talabeya_Task.Application.Tickets.EventHandlers;

public class TicketHandleNeededEventHandler : INotificationHandler<TicketHandleNeededEvent>
{
    private readonly ILogger<TicketHandleNeededEvent> _logger;
    private readonly IApplicationDbContext _context;
    private static DateTime now = DateTime.Now;

    public TicketHandleNeededEventHandler(ILogger<TicketHandleNeededEvent> logger, IApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task Handle(TicketHandleNeededEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Talabeya_Task Domain Event: {DomainEvent}", notification.GetType().Name);
        var tickes = await _context.Tickets
            .Where(x => !x.IsHandeled)
            .ToListAsync(cancellationToken);
        if (tickes.Any(HandleLastHourData))
        {
            foreach (var item in tickes.Where(HandleLastHourData))
            {

                item.IsHandeled = true;
                _context.Tickets.Update(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

    private bool HandleLastHourData(Ticket x)
    {
        return (now - x.Created).TotalMinutes > 60;
    }
}
