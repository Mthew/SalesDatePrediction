using FluentValidation;
using SalesDatePrediction.Domain;
namespace SalesDatePrediction.Application.Feature.Order.Commands.Create
{
    public class CreateOrderWithDetailsCommandValidator : AbstractValidator<CreateOrderWithDetailsCommand>
    {
        public CreateOrderWithDetailsCommandValidator()
        {
            RuleFor(order => order.Empid)
             .GreaterThan(0)
             .WithMessage("Empid debe ser mayor que 0.");

            RuleFor(order => order.Shipperid)
                .GreaterThan(0)
                .WithMessage("Shipperid debe ser mayor que 0.");

            RuleFor(order => order.Shipname)
                .NotEmpty()
                .WithMessage("Shipname no puede estar vacío.")
                .NotNull()
                .WithMessage("Shipname no puede ser nulo.")
                .MaximumLength(80)
                .WithMessage("Shipname no puede tener más de 80 caracteres.");

            RuleFor(order => order.Shipaddress)
                .NotEmpty()
                .WithMessage("Shipaddress no puede estar vacío.")
                .NotNull()
                .WithMessage("Shipaddress no puede ser nulo.")
                .MaximumLength(120)
                .WithMessage("Shipaddress no puede tener más de 120 caracteres.");

            RuleFor(order => order.Shipcity)
                .NotEmpty()
                .WithMessage("Shipcity no puede estar vacío.")
                .NotNull()
                .WithMessage("Shipcity no puede ser nulo.")
                .MaximumLength(30)
                .WithMessage("Shipcity no puede tener más de 30 caracteres.");

            RuleFor(order => order.Orderdate)
                .NotEmpty()
                .WithMessage("Orderdate no puede estar vacío.")
                .NotNull()
                .WithMessage("Orderdate no puede ser nulo.")
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("Orderdate no puede ser una fecha futura.");

            RuleFor(order => order.Requireddate)
                .NotEmpty()
                .WithMessage("Requireddate no puede estar vacío.")
                .NotNull()
                .WithMessage("Requireddate no puede ser nulo.")
                .GreaterThanOrEqualTo(order => order.Orderdate)
                .WithMessage("Requireddate debe ser posterior o igual a Orderdate.");

            RuleFor(order => order.Shippeddate)
                .NotEmpty()
                .WithMessage("Shippeddate no puede estar vacío.")
                .NotNull()
                .WithMessage("Shippeddate no puede ser nulo.")
                .GreaterThanOrEqualTo(order => order.Orderdate)
                .WithMessage("Shippeddate debe ser posterior o igual a Orderdate.");

            RuleFor(order => order.Freight)
                .NotEmpty()
                .WithMessage("Freight no puede estar vacío.")
                .NotNull()
                .WithMessage("Freight no puede ser nulo.")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Freight no puede ser negativo.");

            RuleFor(order => order.Shipcountry)
                .NotEmpty()
                .WithMessage("Shipcountry no puede estar vacío.")
                .NotNull()
                .WithMessage("Shipcountry no puede ser nulo.")
                .MaximumLength(30)
                .WithMessage("Shipcountry no puede tener más de 30 caracteres.");

            RuleFor(order => order.DetailsJson)
                .NotEmpty()
                .WithMessage("DetailsJson no puede estar vacío.")
                .NotNull()
                .WithMessage("DetailsJson no puede ser nulo.");
        }
    }
}


