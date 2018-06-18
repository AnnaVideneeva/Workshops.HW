import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EpisodesPage } from '../models/news-feed/episodes-page';
import { MusicPage } from '../models/news-feed/music-page';
import { Music } from '../models/news-feed/music';
import { SeriesPage } from '../models/news-feed/series-page';
import { SeriesDetails } from '../models/news-feed/series-details';
import { Genre } from '../models/news-feed/genre';
import { MusicDetails } from '../models/news-feed/music-details';
import { Urls } from '../constants';

@Injectable({
  providedIn: 'root'
})
export class NewsFeedService {

  constructor(private http: HttpClient) { }

  getNewEpisodes(page: number, genre: number): Observable<EpisodesPage> {
    return this.http.get<EpisodesPage>(`${Urls.newsApiUrl}/episode/new/page_${page}?page_size=12${genre ? '&genre_id=' + genre : ''}`);
  }

  getMusic(page: number, genre): Observable<MusicPage> {
    return this.http.get<MusicPage>(`${Urls.newsApiUrl}/music/page/${page}${genre ? '?genreId=' + genre : ''}`);
  }

  getNewMusic(page: number, genre): Observable<MusicPage> {
    return this.http.get<MusicPage>(`${Urls.newsApiUrl}/music/new/page/${page}${genre ? '?genreId=' + genre : ''}`);
  }

  getMusicDetails(id: number): Observable<MusicDetails> {
    return this.http.get<MusicDetails>(`${Urls.newsApiUrl}/music/${id}`);
  }

  getSeriesPage(page: number, genre: number): Observable<SeriesPage> {
    return this.http.get<SeriesPage>(`${Urls.newsApiUrl}/tvseries/page_${page}?page_size=12${genre ? '&genre_id=' + genre : ''}`);
  }

  getSeriesDetails(id: number): Observable<SeriesDetails> {
    return this.http.get<SeriesDetails>(`${Urls.newsApiUrl}/tvseries/${id}?episodes_count=5&persons_count=5`);
  }

  getGenres(type: string): Observable<Genre[]> {
    type = type.replace('episodes', 'series');
    return this.http.get<Genre[]>(`${Urls.newsApiUrl}/genre/${type}/all`);
  }

  unsubscribeFromRelease(id: number): Observable<any> {
    return this.http.put<any>(`${Urls.newsApiUrl}/unsubscribe/${id}`, null);
  }

  subscribeOnRelease(id: number): Observable<any> {
    return this.http.put<any>(`${Urls.newsApiUrl}/subscribe/${id}`, null);
  }

}
