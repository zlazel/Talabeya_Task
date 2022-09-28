namespace Talabeya_Task.Domain.Events;

public class TicketCompletedEvent : BaseEvent
{
    public TicketCompletedEvent(Ticket ticket)
    {
        Ticket = ticket;
    }

    public Ticket Ticket { get; }
}
