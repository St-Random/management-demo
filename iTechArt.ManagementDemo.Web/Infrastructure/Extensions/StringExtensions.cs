using System;

namespace iTechArt.ManagementDemo.Web.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string ToCamelCase(this string str)
        {
            if (str == null)
            {
                throw new NullReferenceException();
            }

            if (str.Equals(string.Empty))
            {
                return str;
            }

            return char.ToLowerInvariant(str[0]) + str.Substring(1);
        }
            
    }
}
