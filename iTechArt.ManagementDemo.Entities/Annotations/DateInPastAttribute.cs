using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iTechArt.ManagementDemo.Entities.Annotations
{
    [AttributeUsage(
        AttributeTargets.Property | AttributeTargets.Field,
        AllowMultiple = false,
        Inherited = true)]
    public class DateInPastAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateTime)
            {
                return dateTime <= DateTime.UtcNow;
            }

            return true;
        }
    }
}
