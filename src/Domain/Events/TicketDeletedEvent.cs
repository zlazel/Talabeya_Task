namespace Talabeya_Task.Domain.Events;

public class TicketDeletedEvent : BaseEvent
{
    public TicketDeletedEvent(Ticket ticket)
    {
        Ticket = ticket;
    }

    public Ticket Ticket { get; }
}
