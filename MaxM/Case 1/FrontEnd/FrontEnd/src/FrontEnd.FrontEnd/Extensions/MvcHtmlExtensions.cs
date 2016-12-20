using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace FrontEnd.Extensions
{

    /// <summary>
    /// MvcHtmlExtensions
    /// </summary>
    public static class MvcHtmlExtensions
    {
        /// <summary>
        /// DescriptionFor
        /// HtmlHelper for showing ViewModel description for property
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="html"></param>
        /// <param name="expression"></param>
        /// <returns>HTML</returns>
        public static IHtmlContent DescriptionFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            var modelExplorer = ExpressionMetadataProvider.FromLambdaExpression(expression, html.ViewData, html.MetadataProvider);
            var description = modelExplorer.Metadata.Description;
            return string.IsNullOrWhiteSpace(description) ? HtmlString.Empty : new HtmlString($"<p class='help-block'>{description}</p>");
        }

        /// <summary>
        /// DateForFormat
        /// Prints a Date for given format
        /// </summary>
        /// <param name="html"></param>
        /// <param name="insertedDateTime"></param>
        /// <param name="dateFormat"></param>
        /// <returns></returns>
        public static IHtmlContent DateForFormat(this IHtmlHelper html, DateTime insertedDateTime, DateFormats dateFormat)
        {
            if (insertedDateTime == null)
            {
                return HtmlString.Empty;
            }
            switch (dateFormat)
            {
                case DateFormats.ddMMyyyy:
                    return new HtmlString(insertedDateTime.Date.ToString("dd/MM/yyyy", new CultureInfo("nl-NL")));
                case DateFormats.Unknown:
                    return HtmlString.Empty;
            }
            return HtmlString.Empty;
        }
    }
}
