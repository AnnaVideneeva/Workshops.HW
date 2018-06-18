import { Component, OnInit } from '@angular/core';
import { EpisodesPage } from '../../../models/news-feed/episodes-page';
import { NewsFeedService } from '../../../services/news-feed.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-episodes',
  templateUrl: './episodes.component.html',
  styleUrls: ['./episodes.component.css']
})
export class EpisodesComponent implements OnInit {

  episodesPage: EpisodesPage;

  constructor(private newsService: NewsFeedService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.queryParamMap.subscribe(params =>
      this.onQueryParamsChanged(+params.get('page'), +params.get('genre')));
  }

  onQueryParamsChanged(page: number, genre: number) {
    if (page > 0) {
      this.newsService.getNewEpisodes(page, genre)
        .subscribe(data => this.episodesPage = data);
    }
  }

}
