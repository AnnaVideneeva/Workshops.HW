import { Genre } from './genre';
import { MusicTrack } from './music-track';
import { Music } from './music';

export class MusicDetails extends Music {
  Duration: string;
  Genres: Genre[];
  MusicTracks: MusicTrack[];
}
