using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Options;

namespace SerdehaBlog.Core.TagHelpers
{
    public class GoogleAdsenseOptions
    {
        public string? TrackingCode { get; set; }
    }
    public class GoogleAdsenseTagHelper : TagHelper
    {
        private readonly GoogleAdsenseOptions _googleAdsenseOptions;

        public GoogleAdsenseTagHelper(IOptions<GoogleAdsenseOptions> googleAdsenseOptions)
        {
            _googleAdsenseOptions = googleAdsenseOptions.Value;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (string.Equals(output.TagName, "head", StringComparison.OrdinalIgnoreCase))
            {
                var trackingCode = _googleAdsenseOptions.TrackingCode;
                if (!string.IsNullOrEmpty(trackingCode))
                    output.PostContent
                        .AppendHtml("<script async src='https://pagead2.googlesyndication.com/pagead/js/adsbygoogle.js?client=ca-pub-")
                        .AppendHtml(trackingCode)
                        .AppendHtml("'crossorigin='anonymous'></script>");
            }
        }
    }
}
