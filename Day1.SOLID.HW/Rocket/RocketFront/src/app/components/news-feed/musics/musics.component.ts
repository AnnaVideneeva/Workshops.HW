import { Component, OnInit } from '@angular/core';
import { MusicPage } from '../../../models/news-feed/music-page';
import { NewsFeedService } from '../../../services/news-feed.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-musics',
  templateUrl: './musics.component.html',
  styleUrls: ['./musics.component.css']
})
export class MusicsComponent implements OnInit {

  musicPage: MusicPage;

  constructor(private newsService: NewsFeedService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.queryParamMap.subscribe(params =>
      this.onQueryParamsChanged(+params.get('page'), +params.get('genre')));
  }

  onQueryParamsChanged(page: number, genre: number) {
    if (page > 0) {
      this.newsService.getNewMusic(page, genre)
        .subscribe(data => this.musicPage = data);
    }
  }

}
