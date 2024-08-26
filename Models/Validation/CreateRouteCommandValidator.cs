using FluentValidation;
using TrainTicketsWebApp.CQRS.Commands.Route;

namespace TrainTicketsWebApp.Models.Validation;

public class CreateRouteCommandValidator : AbstractValidator<CreateRouteCommand>
{
    public CreateRouteCommandValidator()
    {
		RuleFor(x => x.Name).NotNull().WithMessage("Nazwa trasy jest obowiązkowa")
								.NotEmpty().WithMessage("Nazwa trasy jest obowiązkowa")
								.MinimumLength(2).WithMessage("Min 2 znaki")
								.MaximumLength(100).WithMessage("Max 100 znaków");
	}
}
