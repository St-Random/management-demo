using Microsoft.AspNetCore.Mvc;
using System;

namespace iTechArt.ManagementDemo.Web.Infrastructure.Binding
{
    // And another hack for UTC dates binding
    [AttributeUsage(
        AttributeTargets.Field | AttributeTargets.Property,
        AllowMultiple = false,
        Inherited = true)]
    public class UtcBinderAttribute : ModelBinderAttribute
    {
        public UtcBinderAttribute() : base(typeof(UtcDateTimeModelBinder))
        { }
    }
}
