using System;
using System.Collections.Generic;
using System.Text;

namespace iTechArt.ManagementDemo.Querying.Attributes
{
    [AttributeUsage(
        AttributeTargets.Field | AttributeTargets.Property,
        AllowMultiple = false,
        Inherited = true)]
    public class DisplayInfoAttribute : Attribute
    {
        public string Name { get; }

        public string Group { get; set; }
        public bool IsVisible { get; set; } = true;


        public DisplayInfoAttribute(string name = null)
        {
            Name = name;
        }
    }
}
