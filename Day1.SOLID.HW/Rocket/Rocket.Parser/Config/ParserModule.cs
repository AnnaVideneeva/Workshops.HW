using System.Net.Http;
using AngleSharp.Parser.Html;
using Ninject.Modules;
using Rocket.DAL.Context;
using Rocket.Parser.Interfaces;
using Rocket.Parser.Parsers;
using Rocket.Parser.Services;

namespace Rocket.Parser.Config
{
    public class ParserModule : NinjectModule
    {
        /// <summary>
        /// Настройка Ninject для парсера
        /// </summary>
        public override void Load()
        {
            Rebind<RocketContext>().ToMethod(ctx => new RocketContext()).InSingletonScope();
            Bind<HttpClient>().ToMethod(ctx => new HttpClient()).InSingletonScope();
            Bind<HtmlParser>().ToMethod(ctx => new HtmlParser()).InSingletonScope();
            Bind<ILoadHtmlService>().To<LoadHtmlService>().InSingletonScope();
            Bind<IAlbumInfoParser>().To<AlbumInfoParser>();
            Bind<ILostfilmParser>().To<LostfilmParser>();
        }
    }
}
