using System;
using System.Linq;
using System.Reflection;

namespace iTechArt.ManagementDemo.Web.Infrastructure.Extensions
{
    public static class ReflectionExtensions
    {
        public static bool HasAttribute<TAttribute>(
            this PropertyInfo propertyInfo)
            where TAttribute : Attribute =>
            propertyInfo.GetCustomAttributes<TAttribute>(true).Any();
    }
}
