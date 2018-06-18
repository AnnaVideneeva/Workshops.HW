import { Season } from './season';
import { Person } from './person';
import { Series } from './series';

export class SeriesDetails extends Series {
  RateImDb: number;
  UrlToOfficialSite: string;
  Seasons: Season[];
  Persons: Person[];
  Summary: string;
}
