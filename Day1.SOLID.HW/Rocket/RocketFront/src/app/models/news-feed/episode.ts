export class Episode {
  Id: number;
  TitleRu: string;
  TitleEn: string;
  ReleaseDateRu: Date;
  ReleaseDateEn: Date;
  SeasonNumber: number;
  Number: number;

  TvSeriesId: number;
  TvSeriesTitleRu: string;
  TvSeriesTitleEn: string;
  PosterImageUrl: string;

  DurationInMinutes: number;
  UrlForEpisodeSource: string;
}
