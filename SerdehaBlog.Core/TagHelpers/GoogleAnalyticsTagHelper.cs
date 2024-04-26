using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Options;

namespace SerdehaBlog.Core.TagHelpers
{
    public class GoogleAnalyticsOptions
    {
        public string? TrackingCode { get; set; }
    }
    public class GoogleAnalyticsTagHelper : TagHelper
    {
        private readonly GoogleAnalyticsOptions _googleAnalyticsOptions;

        public GoogleAnalyticsTagHelper(IOptions<GoogleAnalyticsOptions> googleAnalyticsOptions)
        {
            _googleAnalyticsOptions = googleAnalyticsOptions.Value;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (string.Equals(output.TagName, "head", StringComparison.OrdinalIgnoreCase))
            {
                var trackingCode = _googleAnalyticsOptions.TrackingCode;
                if (!string.IsNullOrEmpty(trackingCode))
                    output.PostContent
                        .AppendHtml($"<script async src='https://www.googletagmanager.com/gtag/js?id={trackingCode}'></script>")
                        .AppendHtml("<script>window.dataLayer = window.dataLayer || [];function gtag(){dataLayer.push(arguments);}gtag('js', new Date());gtag('config', '")
                        .AppendHtml(trackingCode)
                        .AppendHtml("');</script>");
            }
        }
    }
}
