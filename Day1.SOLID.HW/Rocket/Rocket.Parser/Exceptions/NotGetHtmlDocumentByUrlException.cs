using System;

namespace Rocket.Parser.Exceptions
{
    internal class NotGetHtmlDocumentByUrlException : Exception
    {
        private const string ExceptionMessage = "Не удалось загрузить HtmlDocument по ссылке {0}.";

        public NotGetHtmlDocumentByUrlException() : base()
        { }

        public NotGetHtmlDocumentByUrlException(string url)
            : base(string.Format(ExceptionMessage, url))
        { }

        public NotGetHtmlDocumentByUrlException(string url, Exception innerException)
            : base(string.Format(ExceptionMessage, url), innerException)
        { }
    }
}
