internal class FunctionalError
{
    private string _UserStoryCode;
    private string _ErrorMessage;
    private string _Remedy;

    public FunctionalError(string userStoryCode, string errorMessage, string remedy = "no known remedy, please try something else")
    {
        _UserStoryCode = userStoryCode;
        _ErrorMessage = errorMessage;
        _Remedy = remedy;
    }
}