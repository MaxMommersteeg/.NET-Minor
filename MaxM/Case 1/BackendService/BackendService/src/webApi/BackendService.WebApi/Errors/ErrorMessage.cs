using BackendService.WebApi.Errors;

namespace BackendService.WebApi.Errors
{
    internal class ErrorMessage
    {
        public ErrorTypes ErrorType { get; set; }
        public string ErrorDescription { get; set; }
        public string Remedy { get; set; }

        public ErrorMessage(ErrorTypes errorType, string errorDescription, string remedy = null)
        {
            ErrorType = errorType;
            ErrorDescription = errorDescription;
            Remedy = remedy;
        }
    }
}