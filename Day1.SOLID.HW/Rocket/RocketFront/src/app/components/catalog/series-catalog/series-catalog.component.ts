import { Component, OnInit } from '@angular/core';
import { NewsFeedService } from '../../../services/news-feed.service';
import { SeriesPage } from '../../../models/news-feed/series-page';
import { Genre } from '../../../models/news-feed/genre';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-series-catalog',
  templateUrl: './series-catalog.component.html',
  styleUrls: ['./series-catalog.component.css'],
})
export class SeriesCatalogComponent implements OnInit {

  seriesPage: SeriesPage;

  constructor(private newsService: NewsFeedService, private route: ActivatedRoute) {}

  ngOnInit() {
    this.route.queryParamMap.subscribe(params =>
      this.onQueryParamsChanged(+params.get('page'), +params.get('genre')));
  }

  onQueryParamsChanged(page: number, genre: number) {
    if (page > 0) {
      this.newsService.getSeriesPage(page, genre)
        .subscribe(data => this.seriesPage = data);
    }
  }

  subscribeOnRelease(id: number) {
    this.newsService.subscribeOnRelease(id)
      .subscribe(res => this.seriesPage.PageItems.find(x => x.Id === id).IsUserSubscribed = true);
  }

  unsubscribeFromRelease(id: number) {
    this.newsService.unsubscribeFromRelease(id)
      .subscribe(res => this.seriesPage.PageItems.find(x => x.Id === id).IsUserSubscribed = false);
  }

}
