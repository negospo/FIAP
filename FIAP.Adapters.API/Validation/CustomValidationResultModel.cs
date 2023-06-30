using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FIAP.Adapters.API.Validation
{
    public class CustomValidationResultModel
    {
        public string Message { get; }

        public List<CustomValidationError> Errors { get; }

        public CustomValidationResultModel(ModelStateDictionary modelState)
        {
            Message = "Validation Failed";
            Errors = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new CustomValidationError(key, x.ErrorMessage)))
                    .ToList();
        }
    }
}
