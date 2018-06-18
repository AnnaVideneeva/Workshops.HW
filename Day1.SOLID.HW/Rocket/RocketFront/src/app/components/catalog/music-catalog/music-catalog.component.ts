import { Component, OnInit } from '@angular/core';
import { MusicPage } from '../../../models/news-feed/music-page';
import { NewsFeedService } from '../../../services/news-feed.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-music-catalog',
  templateUrl: './music-catalog.component.html',
  styleUrls: ['./music-catalog.component.css']
})
export class MusicCatalogComponent implements OnInit {

  musicPage: MusicPage;

  constructor(private newsService: NewsFeedService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.queryParamMap.subscribe(params =>
      this.onQueryParamsChanged(+params.get('page'), +params.get('genre')));
  }

  onQueryParamsChanged(page: number, genre: number) {
    if (page > 0) {
      this.newsService.getMusic(page, genre)
        .subscribe(data => this.musicPage = data);
    }
  }

  subscribeOnRelease(id: number) {
    this.newsService.subscribeOnRelease(id)
      .subscribe(res => this.musicPage.PageItems.find(x => x.Id === id).IsUserSubscribed = true);
  }

  unsubscribeFromRelease(id: number) {
    this.newsService.unsubscribeFromRelease(id)
      .subscribe(res => this.musicPage.PageItems.find(x => x.Id === id).IsUserSubscribed = false);
  }

}
