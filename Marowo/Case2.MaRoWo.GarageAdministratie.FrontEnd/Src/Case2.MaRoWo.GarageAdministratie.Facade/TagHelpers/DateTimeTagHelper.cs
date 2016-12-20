using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace Case2.MaRoWo.GarageAdministratie.Facade.TagHelpers 
{
    [HtmlTargetElement("div", Attributes = DATETIME_UTC_NAME)]
    public class DateTimeTagHelper : TagHelper
    {
        private const string DATETIME_UTC_NAME = "datetime-utc";
        private const string DATETIME_FORMAT_NAME = "datetime-format";

        private const string TIME_ZONE_ID = "Europe/Amsterdam";
        private const string DEFAULT_DATETIME_FORMAT = "dd-MM-yyyy HH:mm:ss";

        [HtmlAttributeName(DATETIME_UTC_NAME)]
        public DateTime? DateTimeUtc { get; set; }

        [HtmlAttributeName(DATETIME_FORMAT_NAME)]
        public string DateTimeFormat { get; set; } = DEFAULT_DATETIME_FORMAT;

        public override void Process(TagHelperContext context, TagHelperOutput output) 
        {
            if (context == null) 
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (output == null) 
            {
                throw new ArgumentNullException(nameof(output));
            }
            if (DateTimeUtc == null) 
            {
                throw new ArgumentNullException(nameof(DateTimeUtc));
            }

            string dateTimeFormatToUse = string.IsNullOrWhiteSpace(DateTimeFormat) ? DEFAULT_DATETIME_FORMAT : DateTimeFormat;
            string outputDateTime;
            try 
            {
                var europeStandardTimezone = TimeZoneInfo.FindSystemTimeZoneById(TIME_ZONE_ID);
                outputDateTime = TimeZoneInfo.ConvertTime(DateTimeUtc.Value, europeStandardTimezone).ToString(dateTimeFormatToUse);
            }
            catch 
            {
                outputDateTime = $"{DateTimeUtc.Value.ToString(dateTimeFormatToUse)} UTC";
            }
            // Set output
            output.Content.SetHtmlContent(outputDateTime);
        }
    }
}
