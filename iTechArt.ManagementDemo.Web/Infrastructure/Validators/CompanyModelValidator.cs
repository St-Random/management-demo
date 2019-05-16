using FluentValidation;
using iTechArt.ManagementDemo.Web.Infrastructure.Validators.Extensions;
using iTechArt.ManagementDemo.Web.Models;

namespace iTechArt.ManagementDemo.Web.Infrastructure.Validators
{
    public class CompanyModelValidator : AbstractValidator<CompanyModel>
    {
        public CompanyModelValidator()
        {
            RuleSet(
                "ClientCompatible",
                () =>
                {
                    RuleFor(c => c.Name)
                        .NotEmpty()
                        .DefaultLength();

                    RuleFor(c => c.CompanyCode)
                        .DefaultLength();

                    RuleFor(c => c.Email)
                        .EmailAddress()
                        .DefaultLength();

                    RuleFor(c => c.Comment)
                        .DefaultLength();

                    RuleFor(c => c.Phone)
                        .DefaultLength();

                    RuleFor(c => c.Fax)
                        .DefaultLength();
                });

            RuleFor(c => c.DateFounded)
                .DateInPast();

            RuleFor(c => c.Phone)
                .PhoneNumber();

            RuleFor(c => c.Fax)
                .PhoneNumber();

        }
    }
}
