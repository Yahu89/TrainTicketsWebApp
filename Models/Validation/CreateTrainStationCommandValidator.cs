using FluentValidation;
using TrainTicketsWebApp.CQRS.Commands.Station;
using TrainTicketsWebApp.Models.Dto;

namespace TrainTicketsWebApp.Models.Validation;

public class CreateTrainStationCommandValidator : AbstractValidator<CreateTrainStationCommand>
{
    public CreateTrainStationCommandValidator()
    {
        RuleFor(x => x.Station).NotNull().WithMessage("Nazwa stacji jest obowiązkowa")
                                .NotEmpty().WithMessage("Nazwa stacji jest obowiązkowa")
                                .MinimumLength(3).WithMessage("Nazwa stacji musi się składać z co najmniej 3 znaków")
                                .MaximumLength(100).WithMessage("Nazwa stacji nie może przekraczać 100 znaków");
                              
    }
}
