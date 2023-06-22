using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Ports.API.Validation
{
    public class CustonValidationFailedResult : ObjectResult
    {
        public CustonValidationFailedResult(ModelStateDictionary modelState)
            : base(new CustonValidationResultModel(modelState))
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity;
        }
    }
}
