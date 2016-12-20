namespace Minor.Dag21.CAS.BackEnd.WebApi.Errors
{
    public class Foutmelding
    {
        public ErrorTypes ErrorType { get; set; }
        public string ErrorMessage { get; set; }
        public string Remedy { get; set; }

        public Foutmelding(ErrorTypes errorType, string errorMessage, string remedy = null)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
            Remedy = remedy;
        }
    }
}