using FluentValidation;
using TrainTicketsWebApp.CQRS.Commands.TrainType;

namespace TrainTicketsWebApp.Models.Validation;

public class CreateTrainTypeCommandValidator : AbstractValidator<CreateTrainTypeCommand>
{
    public CreateTrainTypeCommandValidator()
    {
        RuleFor(x => x.ShortName).NotNull().WithMessage("Pole nie może być puste")
                                 .NotEmpty().WithMessage("Pole nie może być puste")
                                 .MaximumLength(10).WithMessage("Max 10 znaków");

		RuleFor(x => x.LongName).NotNull().WithMessage("Pole nie może być puste")
								 .NotEmpty().WithMessage("Pole nie może być puste")
								 .MaximumLength(100).WithMessage("Max 100 znaków");

		RuleFor(x => x.TotalPlacesAvailable).Must(val => val == (int)val && val >= 1)
											.WithMessage("Wartość musi być liczbą całkowitą dodatnią");

		RuleFor(x => x.Speed).Must(val => val == (int)val && val >= 1)
											.WithMessage("Wartość musi być liczbą całkowitą dodatnią");
	}
}
