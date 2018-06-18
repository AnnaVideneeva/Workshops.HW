using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;
using Rocket.Parser.Models;

namespace Rocket.Parser.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для загрузки html
    /// </summary>
    internal interface ILoadHtmlService
    {
        /// <summary>
        /// Получает Html в виде строки по ссылке.
        /// </summary>
        /// <param name="url">URL</param>
        /// <returns>Html в виде строки</returns>
        Task<string> GetTextByUrlAsync(string url);

        /// <summary>
        /// Получает файл по ссылке и сохраняет по указанному пути
        /// </summary>
        /// <param name="url">Ссылка на файл</param>
        /// <param name="path">Путь для сохранения</param>
        /// <returns>Task</returns>
        Task DownloadFile(string url, string path);

        /// <summary>
        /// Получает Html по ссылке.
        /// </summary>
        /// <param name="url">URL</param>
        /// <returns>HtmlDocument</returns>
        Task<IHtmlDocument> GetHtmlDocumentByUrlAsync(string url);

        /// <summary>
        /// Получает список моделей html по списку ссылок.
        /// </summary>
        /// <param name="listUrl">Список ссылок для получения html</param>
        /// <param name="maxRequestCount">Максимальное кол-во запросов к сайту.</param>
        /// <returns>Список моделей html</returns>
        List<HtmlDocumentModel> GetListHtmlDocumentModel(List<string> listUrl, int maxRequestCount);
    }
}