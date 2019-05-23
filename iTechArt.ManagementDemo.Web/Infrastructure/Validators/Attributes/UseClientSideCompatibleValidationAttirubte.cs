using FluentValidation.AspNetCore;
using System;

namespace iTechArt.ManagementDemo.Web.Infrastructure.Validators.Attributes
{
    [AttributeUsage(
        AttributeTargets.Method, AllowMultiple = false, Inherited = true )]
    public class UseClientSideCompatibleValidationAttribute
        : RuleSetForClientSideMessagesAttribute
    {
        public const string RULESET = "ClientCompatible";

        public UseClientSideCompatibleValidationAttribute()
            : base(RULESET)
        { }
    }
}
