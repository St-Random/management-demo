using System;

namespace iTechArt.ManagementDemo.Querying.Attributes
{
    [AttributeUsage(
        AttributeTargets.Property,
        AllowMultiple = false,
        Inherited = true)]
    public class AllowSearchAttribute : Attribute
    {
    }
}
