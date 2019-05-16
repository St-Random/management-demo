using FluentValidation;
using iTechArt.ManagementDemo.Web.Infrastructure.Validators.Extensions;
using iTechArt.ManagementDemo.Web.Models;

namespace iTechArt.ManagementDemo.Web.Infrastructure.Validators
{
    public class LocationModelValidator : AbstractValidator<LocationModel>
    {
        public LocationModelValidator()
        {
            RuleSet(
                "ClientCompatible",
                () =>
                {
                    RuleFor(l => l.Name)
                        .NotEmpty()
                        .DefaultLength();

                    RuleFor(l => l.Address)
                        .NotNull()
                        .SetValidator(new AddressModelValidator());

                    RuleFor(l => l.Email)
                        .EmailAddress()
                        .DefaultLength();

                    RuleFor(l => l.Phone)
                        .DefaultLength();

                    RuleFor(l => l.Fax)
                        .DefaultLength();

                    RuleFor(l => l.Comment)
                        .DefaultLength();
                });

            RuleFor(l => l.Phone)
                .PhoneNumber();

            RuleFor(l => l.Fax)
                .PhoneNumber();

            RuleFor(l => l)
                .Must(l => l.CompanyId > 0)
                .WithMessage("Location must be assigned to company.");
        }
    }
}
