using AngleSharp.Dom.Html;

namespace Rocket.Parser.Models
{
    public class HtmlDocumentModel
    {
        public string Url { get; set; }

        public IHtmlDocument HtmlDocument { get; set; }
    }
}
