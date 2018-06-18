import { Component, OnInit } from '@angular/core';
import { SeriesDetails } from '../../../models/news-feed/series-details';
import { NewsFeedService } from '../../../services/news-feed.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-series-details',
  templateUrl: './series-details.component.html',
  styleUrls: ['./series-details.component.css']
})
export class SeriesDetailsComponent implements OnInit {

  series: SeriesDetails;

  constructor(private newsService: NewsFeedService, private route: ActivatedRoute) { }

  ngOnInit() {
    const seriesId = +this.route.snapshot.paramMap.get('id');
    this.getSeriesDetails(seriesId);
  }

  getSeriesDetails(id: number) {
    this.newsService.getSeriesDetails(id)
       .subscribe(data => this.series = data);
  }

}
