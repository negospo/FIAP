using Microsoft.AspNetCore.Mvc.Filters;

namespace FIAP.Adapters.API.Validation
{
    public class CustomValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new CustomValidationFailedResult(context.ModelState);
            }
        }
    }
}
