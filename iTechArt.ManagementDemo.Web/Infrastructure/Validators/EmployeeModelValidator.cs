using FluentValidation;
using iTechArt.ManagementDemo.Web.Models;
using iTechArt.ManagementDemo.Web.Infrastructure.Validators.Extensions;

namespace iTechArt.ManagementDemo.Web.Infrastructure.Validators
{
    public class EmployeeModelValidator : AbstractValidator<EmployeeModel>
    {
        public EmployeeModelValidator()
        {
            RuleSet(
                "ClientCompatible",
                () =>
                {
                    RuleFor(e => e.FirstName)
                        .NotEmpty()
                        .DefaultLength();

                    RuleFor(e => e.MiddleInitial)
                        .DefaultLength();

                    RuleFor(e => e.LastName)
                        .DefaultLength();

                    RuleFor(e => e.Patronymic)
                        .DefaultLength();

                    RuleFor(e => e.Gender)
                        .DefaultLength();

                    RuleFor(e => e.Email)
                        .EmailAddress()
                        .DefaultLength();

                    RuleFor(e => e.PhoneNumber)
                        .DefaultLength();

                    RuleFor(e => e.Skype)
                        .DefaultLength();

                    RuleFor(e => e.Position)
                        .DefaultLength();

                    RuleFor(e => e.SalaryInUSD)
                        .GreaterThan(0)
                        .ScalePrecision(2, 12);

                    RuleFor(e => e.Comment)
                        .DefaultLength();
                });

            RuleFor(e => e)
                .MinEmploymentAge(0);

            RuleFor(e => e.PhoneNumber)
                .PhoneNumber();

            RuleFor(e => e.DateOfBirth)
                .DateInPast();

            RuleFor(e => e)
                .Must(e => e.LocationId > 0)
                .WithMessage("Employee must be assigned to location.");
        }
    }
}
