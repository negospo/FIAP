namespace FIAP.Adapters.API.Validation
{
    public class CustomValidationError
    {
        public string Field { get; }

        public string Message { get; }

        public CustomValidationError(string field, string message)
        {
            Field = field != string.Empty ? field : null;
            Message = message;
        }
    }
}
