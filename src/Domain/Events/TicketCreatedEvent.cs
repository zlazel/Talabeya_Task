namespace Talabeya_Task.Domain.Events;

public class TicketCreatedEvent : BaseEvent
{
    public TicketCreatedEvent(Ticket ticket)
    {
        Ticket = ticket;
    }

    public Ticket Ticket { get; }
}
