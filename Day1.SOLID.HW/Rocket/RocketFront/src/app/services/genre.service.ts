import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Genre } from '../models/news-feed/genre';

@Injectable({
  providedIn: 'root'
})
export class GenreService {

private genreSource = new Subject<Genre>();

genre = this.genreSource.asObservable();

setGenre(genre: Genre) {
  this.genreSource.next(genre);
}

}
