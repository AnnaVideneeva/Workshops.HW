namespace Rocket.Parser.Models
{
    /// <summary>
    /// Релиз музыки на сайте album-info.ru
    /// </summary>
    public class AlbumInfoRelease
    {
        /// <summary>
        /// Id внутри ресурса
        /// </summary>
        public string ResourceInternalId { get; set; }

        /// <summary>
        /// Id элемента ресурса
        /// </summary>
        public int ResourceItemId { get; set; }

        /// <summary>
        /// Название релиза
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата релиза
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// URL изображение релиза
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// URL изображение релиза c адресом ресурса (полный путь)
        /// </summary>
        public string ImageFullUrl { get; set; }

        /// <summary>
        /// Жанр релиза
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// Список треков
        /// </summary>
        public string TrackList { get; set; }

        /// <summary>
        /// Путь к файлу обложки релиза в файловой системе
        /// </summary>
        public string CoverPath { get; set; }
    }
}
