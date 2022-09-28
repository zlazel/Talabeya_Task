using FluentValidation;

namespace Talabeya_Task.Application.Tickets.Commands.UpdateTicket;

public class UpdateTicketCommandValidator : AbstractValidator<HandleTicketCommand>
{
    public UpdateTicketCommandValidator()
    {
        RuleFor(v => v.Id).NotNull().NotEmpty();
    }
}
