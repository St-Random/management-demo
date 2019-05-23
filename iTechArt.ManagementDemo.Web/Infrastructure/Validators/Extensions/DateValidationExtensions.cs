using FluentValidation;
using FluentValidation.Results;
using iTechArt.ManagementDemo.Web.Models;
using System;

namespace iTechArt.ManagementDemo.Web.Infrastructure.Validators.Extensions
{
    public static class DateValidationExtensions
    {
        public static IRuleBuilderOptions<T, DateTime> DateInPast<T>(
            this IRuleBuilder<T, DateTime> ruleBuilder) =>
            ruleBuilder.LessThanOrEqualTo(DateTime.UtcNow);

        public static IRuleBuilderOptions<T, DateTime?> DateInPast<T>(
            this IRuleBuilder<T, DateTime?> ruleBuilder) =>
            ruleBuilder
                .LessThanOrEqualTo(DateTime.UtcNow);

        public static IRuleBuilderInitial<EmployeeModel, EmployeeModel>
            MinEmploymentAge(
                this IRuleBuilder<EmployeeModel, EmployeeModel>
                    ruleBuilder,
                int minAge) =>
            ruleBuilder.Custom(
                (e, ctx) =>
                {
                    if (!e.DateOfBirth.HasValue
                        || !e.DateOfEmployment.HasValue)
                    {
                        return;
                    }

                    var dateOfEmployment = e.DateOfEmployment.Value;
                    var dateOfBirth = e.DateOfBirth.Value;

                    var employmentAge = dateOfEmployment.Year
                        - dateOfBirth.Year;

                    if (dateOfBirth.AddYears(employmentAge)
                        > dateOfEmployment)
                    {
                        employmentAge--;
                    }

                    if (employmentAge < minAge)
                    {
                        var propertyName =
                            nameof(EmployeeModel.DateOfEmployment);

                        ctx.AddFailure(
                            new ValidationFailure(
                                propertyName,
                                $"Min employment age is {minAge}"));
                    }
                });
    }
}
