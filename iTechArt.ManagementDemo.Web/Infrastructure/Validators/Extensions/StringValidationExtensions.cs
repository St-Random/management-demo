using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace iTechArt.ManagementDemo.Web.Infrastructure.Validators.Extensions
{
    public static class StringValidationExtensions
    {
        // For 100% BL compatibility
        private static readonly PhoneAttribute PhoneAttribute
            = new PhoneAttribute();

        public static IRuleBuilderOptions<T, string> DefaultLength<T>(
            this IRuleBuilder<T, string> ruleBuilder) =>
            ruleBuilder.MaximumLength(255);

        public static IRuleBuilderOptions<T, string> PhoneNumber<T>(
            this IRuleBuilder<T, string> ruleBuilder) =>
            ruleBuilder
                .Must(str => PhoneAttribute.IsValid(str))
                .WithMessage("{0} must be a phone number.");
    }
}
