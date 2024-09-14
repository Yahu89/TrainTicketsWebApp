using FluentValidation;
using TrainTicketsWebApp.Models.Dto;

namespace TrainTicketsWebApp.Models.Validation;

//public class ReservationValidator : AbstractValidator<ReservationDto>
//{
//    public ReservationValidator()
//    {
//		//RuleFor(x => x.FirstName).NotNull().WithMessage("Imię jest obowiązkowe")
//		//						.NotEmpty().WithMessage("Imię jest obowiązkowe")
//		//						.MinimumLength(2).WithMessage("Imię musi się składać z co najmniej 2 znaków")
//		//						.MaximumLength(200).WithMessage("Imię nie może przekraczać 200 znaków");

//		//RuleFor(x => x.LastName).NotNull().WithMessage("Nazwisko jest obowiązkowe")
//		//						.NotEmpty().WithMessage("Nazwisko jest obowiązkowe")
//		//						.MinimumLength(2).WithMessage("Nazwisko musi się składać z co najmniej 2 znaków")
//		//						.MaximumLength(200).WithMessage("Nazwisko nie może przekraczać 200 znaków");

//		//RuleFor(x => x.Email).NotNull().WithMessage("Adres e-mail jest obowiązkowy")
//		//						.NotEmpty().WithMessage("Adres e-mail jest obowiązkowy")
//		//						.EmailAddress().WithMessage("Nieprawidłowy format danych. Podaj adres e-mail.");
//	}
//}
