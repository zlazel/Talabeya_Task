using FluentValidation;

namespace Talabeya_Task.Application.Tickets.Commands.CreateTicket;

public class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
{
    public CreateTicketCommandValidator()
    {
        RuleFor(v => v.Phone)
            .MaximumLength(15)
            .NotEmpty();

        RuleFor(v => v.Goverenorate).NotNull().NotEmpty().NotEqual(0);
        RuleFor(v => v.City).NotNull().NotEmpty().NotEqual(0);
        RuleFor(v => v.District).NotNull().NotEmpty().NotEqual(0);
    }
}
