import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaderResponse, HttpErrorResponse} from '@angular/common/http';
import { Profile } from '../models/personal-area/profile';
import { Observable } from 'rxjs';
import { Email } from '../models/personal-area/email';
import { GenreMusic } from '../models/personal-area/genreMusic';
import { GenreTv } from '../models/personal-area/genreTv';
import { Urls } from '../../app/constants';

@Injectable()
export class DataService {
    constructor(private http: HttpClient) {}
    getData(): Observable<Profile> {
       return this.http.get<Profile>(`${Urls.signalRUrl}/personal/user`);
    }

    getListGenreMusic(): Observable<GenreMusic> {
        return this.http.get<GenreMusic>(`${Urls.signalRUrl}/genres/all/music`);
     }

     getListGenreTv(): Observable<GenreTv> {
        return this.http.get<GenreTv>(`${Urls.signalRUrl}/genres/all/tv`);
     }
    changeData(user: Profile): Observable<Profile> {
       return this.http.put<Profile>(
        `${Urls.signalRUrl}/personal/user/info/?firstName=${user.FirstName}&lastName=${user.LastName}&avatar=${user.Avatar}`, null);
    }

    changePassword(pass: string, passConfirm: string): Observable<Profile> {
        return this.http.put<Profile>(
        `${Urls.signalRUrl}/personal/user/password/?password=${pass}&passwordConfirm=${passConfirm}`, null);
    }

    addemail(email: Email): Observable<Email> {
         return this.http.post<Email>(`${Urls.signalRUrl}/personal/email/add/`, email);
    }

    deleteemail(id: number): Observable<HttpErrorResponse> {
       return this.http.delete<HttpErrorResponse>(`${Urls.signalRUrl}/personal/email/delete/${id}`);
    }
    addMusicGenre(user: Profile, genre: string): Observable<HttpErrorResponse> {
        return this.http.post<HttpErrorResponse>(`${Urls.signalRUrl}/personal/genres/music/add?id=${user.Id}&genre=${genre}`, null);
    }
    deleteMusicGenre(user: Profile, genre: string): Observable<HttpErrorResponse> {
        return this.http.post<HttpErrorResponse>(`${Urls.signalRUrl}/personal/genres/music/delete?id=${user.Id}&genre=${genre}`, null);
    }

    addTvGenre(user: Profile, genre: string): Observable<HttpErrorResponse> {
        return this.http.post<HttpErrorResponse>(`${Urls.signalRUrl}/personal/genres/tv/add?id=${user.Id}&genre=${genre}`, null);
    }
    deletTvGenre(user: Profile, genre: string): Observable<HttpErrorResponse> {
        return this.http.post<HttpErrorResponse>(`${Urls.signalRUrl}/personal/genres/tv/delete?id=${user.Id}&genre=${genre}`, null);
    }
}
