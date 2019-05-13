using System;
using System.ComponentModel.DataAnnotations;

namespace iTechArt.ManagementDemo.Entities.Annotations
{
    [AttributeUsage(
        AttributeTargets.Property | AttributeTargets.Field,
        AllowMultiple = false,
        Inherited = true)]
    public class UtcDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateTime)
            {
                return dateTime.Kind == DateTimeKind.Utc;
            }

            return true;
        }
    }
}
