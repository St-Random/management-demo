using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Threading.Tasks;

namespace iTechArt.ManagementDemo.Web.Infrastructure.Binding
{
    // A hack for UTC dates binding
    public class UtcDateTimeModelBinder : IModelBinder
    {
        private readonly IModelBinder _dateTimeBinder =
#pragma warning disable CS0618 // Type or member is obsolete
            new SimpleTypeModelBinder(typeof(DateTime?));
#pragma warning restore CS0618 // Type or member is obsolete

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            await _dateTimeBinder.BindModelAsync(bindingContext);

            if (bindingContext.Result.IsModelSet
                && bindingContext.Result.Model != null)
            {
                var dateTime = (DateTime)bindingContext.Result.Model;

                bindingContext.Result = ModelBindingResult.Success(
                    DateTime.SpecifyKind(dateTime, DateTimeKind.Utc));
            }
        }
    }
}
