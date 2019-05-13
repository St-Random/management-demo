using System;
using System.ComponentModel.DataAnnotations;

namespace iTechArt.ManagementDemo.Entities.Annotations
{
    [AttributeUsage(
        AttributeTargets.Class,
        AllowMultiple = false,
        Inherited = true)]
    public class MinEmploymentAgeAttribute : ValidationAttribute
    {
        public int MinAge { get; }


        public MinEmploymentAgeAttribute(int minAge)
        {
            MinAge = minAge;
        }


        public override bool IsValid(object value)
        {
            if (value is Employee employee)
            {
                if (!employee.DateOfBirth.HasValue
                    || !employee.DateOfEmployment.HasValue)
                {
                    return true;
                }

                var dateOfEmployment = employee.DateOfEmployment.Value;
                var dateOfBirth = employee.DateOfBirth.Value;

                var employmentAge = dateOfEmployment.Year - dateOfBirth.Year;

                if (dateOfBirth.AddYears(employmentAge) > dateOfEmployment)
                {
                    employmentAge--;
                }

                return employmentAge >= MinAge;
            }

            return true;
        }
    }
}
