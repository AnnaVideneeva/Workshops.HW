import { Component, OnInit } from '@angular/core';
import { MusicDetails } from '../../../models/news-feed/music-details';
import { NewsFeedService } from '../../../services/news-feed.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-musics-details',
  templateUrl: './musics-details.component.html',
  styleUrls: ['./musics-details.component.css']
})
export class MusicsDetailsComponent implements OnInit {

  musicDetails: MusicDetails;

  constructor(private newsService: NewsFeedService, private route: ActivatedRoute) { }

  ngOnInit() {
    const musicId = +this.route.snapshot.paramMap.get('id');
    this.getSeriesDetails(musicId);
  }

  getSeriesDetails(id: number) {
    this.newsService.getMusicDetails(id)
       .subscribe(data => this.musicDetails = data);
  }
}
