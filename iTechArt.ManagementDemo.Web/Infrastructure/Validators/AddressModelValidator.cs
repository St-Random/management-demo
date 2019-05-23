using FluentValidation;
using iTechArt.ManagementDemo.Web.Infrastructure.Validators.Attributes;
using iTechArt.ManagementDemo.Web.Infrastructure.Validators.Extensions;
using iTechArt.ManagementDemo.Web.Models;

namespace iTechArt.ManagementDemo.Web.Infrastructure.Validators
{
    public class AddressModelValidator : AbstractValidator<AddressModel>
    {
        public AddressModelValidator()
        {
            RuleSet(
                UseClientSideCompatibleValidationAttribute.RULESET,
                () =>
                {
                    RuleFor(a => a.Country)
                        .NotEmpty()
                        .DefaultLength();

                    RuleFor(a => a.Area)
                        .NotEmpty()
                        .DefaultLength();

                    RuleFor(a => a.City)
                        .NotEmpty()
                        .DefaultLength();

                    RuleFor(a => a.AddressLine1)
                        .NotEmpty()
                        .DefaultLength();

                    RuleFor(a => a.AddressLine2)
                        .DefaultLength();

                    RuleFor(a => a.PostalCode)
                        .NotEmpty()
                        .DefaultLength();
                });
        }
    }
}
