using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Adapters.API.Validation
{
    public class CustomValidationFailedResult : ObjectResult
    {
        public CustomValidationFailedResult(ModelStateDictionary modelState)
            : base(new CustomValidationResultModel(modelState))
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity;
        }
    }
}
