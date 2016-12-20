namespace Minor.DagXX.XXX1.WebApi.Errors
{
    internal class ErrorMessage
    {
        public ErrorType ErrorType { get; set; }
        public string ErrorMessage { get; set; }
        public string Remedy { get; set; }

        public ErrorMessage(ErrorType errorType, string errorMessage, string remedy = null)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
            Remedy = remedy;
        }
    }
}