using System;

namespace Rocket.Parser.Exceptions
{
    internal class AlbumInfoReleaseException : Exception
    {
        private const string ExceptionMessage = "Ошибка парсинга сайта album-info.ru. {0}";

        public AlbumInfoReleaseException() : base()
        {
        }

        public AlbumInfoReleaseException(string str) : base(string.Format(ExceptionMessage, str))
        {
        }

        public AlbumInfoReleaseException(string str, Exception innerException)
            : base(string.Format(ExceptionMessage, str), innerException)
        {
        }
    }
}
