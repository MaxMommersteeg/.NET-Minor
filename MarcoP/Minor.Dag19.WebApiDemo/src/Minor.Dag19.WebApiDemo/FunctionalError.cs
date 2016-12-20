namespace Minor.Dag19.WebApiDemo.Controllers
{
    internal class FunctionalError
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public FunctionalError(string v1, string v2)
        {
            ErrorCode = v1;
            ErrorMessage = v2;
        }
    }
}