using BilleteraAPI.Application.Dtos;
using FluentValidation;

namespace BilleteraAPI.Application.Validators
{
    public class BilleteraValidator : AbstractValidator<BilleteraDto>
    {
        public BilleteraValidator() {
            RuleFor(x => x.DocumentId)
                .NotEmpty().WithMessage("El DocumentId no puede estar vacío.")
                .Length(5, 25).WithMessage("El DocumentId debe tener entre 5 y 25 caracteres.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre no puede estar vacío.")
                .MaximumLength(60).WithMessage("El nombre no puede exceder los 60 caracteres.");


            RuleFor(x => x.Balance)
                .GreaterThanOrEqualTo(0).WithMessage("El monto no puede ser un numero negativo");
        }
    }
}
