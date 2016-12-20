namespace FrontEnd.ViewModels.Shared
{
    internal interface IPageHeader
    {
        /// <summary>
        /// GetTitle
        /// Returns the title of a PageHeader
        /// </summary>
        /// <returns>string</returns>
        string GetTitle();

        /// <summary>
        /// GetDescription
        /// Returns the description of a PageHeader
        /// </summary>
        /// <returns></returns>
        string GetDescription();
    }
}
