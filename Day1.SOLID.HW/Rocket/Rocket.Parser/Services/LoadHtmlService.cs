using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using Rocket.Parser.Interfaces;
using Rocket.Parser.Models;

namespace Rocket.Parser.Services
{
    /// <inheritdoc />
    /// <summary>
    /// Сервис для загрузки html
    /// </summary>
    public class LoadHtmlService : ILoadHtmlService
    {
        private readonly HttpClient _httpClient;
        private readonly HtmlParser _domParser;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="httpClient">httpClient</param>
        /// <param name="domParser">HtmlParser</param>
        public LoadHtmlService(HttpClient httpClient, HtmlParser domParser)
        {
            _httpClient = httpClient;
            _domParser = domParser;
        }

        /// <inheritdoc />
        /// <summary>
        /// Получает Html в виде строки по ссылке.
        /// </summary>
        /// <param name="url">URL</param>
        /// <returns>Html в виде строки</returns>
        public async Task<string> GetTextByUrlAsync(string url)
        {
            var response = await _httpClient.GetAsync(url).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var source = string.Empty;

            source = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return source;
        }

        /// <inheritdoc />
        /// <summary>
        /// Получает файл по ссылке и сохраняет по указанному пути
        /// </summary>
        /// <param name="url">Ссылка на файл</param>
        /// <param name="path">Путь для сохранения</param>
        /// <returns></returns>
        public async Task DownloadFile(string url, string path)
        {
            var response = await _httpClient.GetAsync(url).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            {
                using (
                    Stream contentStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                        stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await contentStream.CopyToAsync(stream);
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Получает Html по ссылке.
        /// </summary>
        /// <param name="url">URL</param>
        /// <returns>HtmlDocument</returns>
        public async Task<IHtmlDocument> GetHtmlDocumentByUrlAsync(string url)
        {
            var source = await GetTextByUrlAsync(url).ConfigureAwait(false);

            var htmldocument = await _domParser.ParseAsync(source).ConfigureAwait(false);

            return htmldocument;
        }

        /// <inheritdoc />
        /// <summary>
        /// Получает список моделей html по списку ссылок.
        /// </summary>
        /// <param name="listUrl">Список ссылок для получения html</param>
        /// <param name="maxRequestCount">Максимальное кол-во запросов к сайту.</param>
        /// <returns>Список моделей html</returns>
        public List<HtmlDocumentModel> GetListHtmlDocumentModel(List<string> listUrl, int maxRequestCount)
        {
            //Формируем список тасок
            int tvSeriasCount = listUrl.Count;
            var listTaskGetHtmlDocumentModel = new Task<HtmlDocumentModel>[tvSeriasCount];
            int taskCounter = 0;
            foreach (var url in listUrl)
            {
                var taskGetHtmlDocumentModel = GetHtmlDocumentModelAsync(url);
                listTaskGetHtmlDocumentModel[taskCounter] = taskGetHtmlDocumentModel;
                taskCounter++;
            }

            int skipTask = 0;
            for (int i = 0; i < tvSeriasCount; i = i + maxRequestCount)
            {
                //Дожидаемся выполнение тасок
                Task.WaitAll(listTaskGetHtmlDocumentModel.Skip(skipTask).Take(maxRequestCount).ToArray());
                skipTask += maxRequestCount;
            }

            var listHtmlDocumentModel = listTaskGetHtmlDocumentModel
                .Select(taskGetHtmlDocument => taskGetHtmlDocument.Result)
                .ToList();

            return listHtmlDocumentModel;
        }

        /// <summary>
        /// Получает HtmlDocumentModel по ссылке.
        /// </summary>
        /// <param name="url">URL</param>
        /// <returns>HtmlDocument</returns>
        private async Task<HtmlDocumentModel> GetHtmlDocumentModelAsync(string url)
        {
            var htmldocument = await GetHtmlDocumentByUrlAsync(url).ConfigureAwait(false);

            var htmlDocumentModel = new HtmlDocumentModel
            {
                HtmlDocument = htmldocument,
                Url = url
            };

            return htmlDocumentModel;
        }
    }
}
