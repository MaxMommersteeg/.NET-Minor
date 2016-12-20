using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace FE.HtmlHelpers
{
    public static class DisplayMeasure
    {
        public static HtmlString DisplayCL(this IHtmlHelper htmlHelper, double contents)
        {
            return new HtmlString(String.Format($"{contents}CL"));
        }
    }
}
