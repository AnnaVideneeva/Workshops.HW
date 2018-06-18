using System;

namespace Rocket.Parser.Exceptions
{
    internal class NotGetTextByUrlException : Exception
    {
        private const string ExceptionMessage = "Не удалось загрузить текст по ссылке {0}.";

        public NotGetTextByUrlException() : base()
        { }

        public NotGetTextByUrlException(string url)
            : base(string.Format(ExceptionMessage, url))
        { }

        public NotGetTextByUrlException(string url, Exception innerException)
            : base(string.Format(ExceptionMessage, url), innerException)
        { }
    }
}
