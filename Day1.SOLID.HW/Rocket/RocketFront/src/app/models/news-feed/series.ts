import { Genre } from './genre';

export class Series {
  Id: number;
  TitleRu: string;
  TitleEn: string;
  PosterImageUrl: string;
  LostfilmRate: number;
  CurrentStatus: string;
  TvSerialCanal: string;
  TvSerialYearStart: string;
  Genres: Genre[];
  IsUserSubscribed: boolean;
}
