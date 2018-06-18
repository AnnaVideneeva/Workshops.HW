import { Component, OnInit } from '@angular/core';
import { Genre } from '../../../models/news-feed/genre';
import { NewsFeedService } from '../../../services/news-feed.service';
import {
  ActivatedRoute,
  Router,
  ChildActivationEnd
} from '@angular/router';

@Component({
  selector: 'app-genres',
  templateUrl: './genres.component.html',
  styleUrls: ['./genres.component.css']
})
export class GenresComponent implements OnInit {

  type: string;
  selectedGenre: Genre;
  genres: Genre[];

  constructor(
    private newsService: NewsFeedService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    router.events.subscribe(event => {
      if (event instanceof ChildActivationEnd) {
        this.route.firstChild.url.subscribe(url => {
          const newType = url.values().next().value.path;
            if (newType !== this.type) {
              this.type = newType;
              this.getGenres(newType);
            }
        });
      }
    });
  }

  ngOnInit() {}

  getGenres(type: string) {
    this.newsService.getGenres(type).subscribe(data => {
      this.genres = data;
      this.route.queryParamMap.subscribe(params =>
        this.onQueryParamsChanged(+params.get('genre'))
      );
    });
  }

  onQueryParamsChanged(genreId: number) {
    this.selectedGenre = this.genres.find(x => x.Id === genreId);
  }
}
