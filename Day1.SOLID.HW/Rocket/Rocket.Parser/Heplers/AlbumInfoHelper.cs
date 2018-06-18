using System.Collections.Specialized;
using System.Configuration;

namespace Rocket.Parser.Heplers
{
    internal static class AlbumInfoHelper
    {
        //настройки ресурса
        private const string AlbumInfoResourceKey = "AlbumInfoResource";

        //regEx
        public const string ReleaseNamePattern = @"(?<=\- )(?: ?+[^\(])++";
        public const string ReleaseTypePattern = @"(?<=\()\w++";
        public const string ReleaseGenrePattern = @"\w[^,]*+";
        public const string ReleaseTrackListPattern = @"([^\. ]\w?+[^\.][^\d]*+)++";

        //formats
        public const string LongDateFormat = "d MMMM yyyy г.";
        public const string ShortDateFormat = "yyyy";

        //path
        public const string CoversPath = @"c:\tmp\MusicCovers\";

        //exception
        public const string EmptyReleaseException = "Отсутствуют данные в коллекции релизов.";
        public const string ParsReleaseException = "Релиз {0} не распаршен.";

        //unknown release
        public const string UnknownArtist = "unknownArtist";
        public const string UnknownName = "unknownName";

        private static readonly NameValueCollection ResourceSettings;

        static AlbumInfoHelper()
        {
            ResourceSettings = (NameValueCollection)ConfigurationManager.GetSection(
                ProjectNameConstants.AlbumInfoSectionGroupName + "/" + 
                ProjectNameConstants.ResourceSettingsSectionName);
        }

        public static string GetAlbumInfoResource()
        {
            return ResourceSettings.Get(AlbumInfoResourceKey);
        }
    }
}
