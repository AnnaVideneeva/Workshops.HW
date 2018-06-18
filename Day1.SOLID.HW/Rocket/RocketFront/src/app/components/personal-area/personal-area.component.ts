import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import {Profile} from '../../models/personal-area/profile';
import {HttpClientModule, HttpErrorResponse, HttpResponse} from '@angular/common/http';
import { DataService } from '../../services/profile.data.service';
import { Email } from '../../models/personal-area/email';
import { ListGenreMusic } from '../../models/personal-area/listGenreMusic';
import { GenreMusic } from '../../models/personal-area/genreMusic';
import { GenreTv } from '../../models/personal-area/genreTv';

@Component({
  selector: 'app-personal-area',
  templateUrl: './personal-area.component.html',
  styleUrls: ['./personal-area.component.css'],
  providers: [DataService]
})
export class PersonalAreaComponent implements OnInit {
  data: Profile;
  errorMessage: string;
  listGenreMisic: Array<GenreMusic>;
  listGenreTv: Array<GenreTv>;
  listGenreMusicForFront: Array<GenreMusic>;
  listGenreTvForFront: Array<GenreTv>;
  dataGenreMusicForFront: Array<string>;
  dataGenreTvForFront: Array<string>;

  constructor(private dataservice: DataService, private changeDetectorRef: ChangeDetectorRef) {
    this.data = new Profile();
    this.data.Emails = new Array<Email>();
    this.listGenreMisic = new Array<GenreMusic>();
    this.listGenreTv = new Array<GenreTv>();
    this.listGenreMusicForFront = new Array<GenreMusic>();
    this.dataGenreMusicForFront = new Array<string>();
    this.dataGenreTvForFront = new Array<string>();
  }

  changeUserInfo() {
    this.dataservice.changeData(this.data).subscribe();
  }

  changeUserPassword(pass: string, passConfirm: string) {
    this.dataservice.changePassword(pass, passConfirm).subscribe();
  }

  addEmail(newEmail: string) {
    const addemail =  new Email();
    addemail.Name = newEmail;
    this.dataservice.addemail(addemail).subscribe
    ((data) => {
      addemail.Id = data.Id;
      this.data.Emails.push(addemail);
      }, (err: HttpErrorResponse) => {
        this.errorMessage = err.message;
      });
  }

  deleteEmail(deleteEmailId: number, name: string) {
    this.dataservice.deleteemail(deleteEmailId).subscribe();
    this.data.Emails.splice(this.data.Emails.findIndex(value => value.Name === name), 1);
  }
  addGenreMusic(selectedGenreMusic: string) {
    if (selectedGenreMusic != null) {
      this.dataGenreMusicForFront.push(selectedGenreMusic);
      this.dataservice.addMusicGenre(this.data, selectedGenreMusic).subscribe();
    }
  }
  deleteMusicGenre(genMusic: string, index: number) {
      this.dataservice.deleteMusicGenre(this.data, genMusic).subscribe();
      this.dataGenreMusicForFront.splice(index, 1);
      this.changeDetectorRef.detectChanges();
  }
  addGenreTv(selectedGenreTv: string) {
    if (selectedGenreTv != null) {
      this.dataGenreTvForFront.push(selectedGenreTv);
      this.dataservice.addTvGenre(this.data, selectedGenreTv).subscribe();
    }
  }
  deleteTvGenre(genTv: string, index: number) {
    this.dataservice.deletTvGenre(this.data, genTv).subscribe();
    this.dataGenreTvForFront.splice(index, 1);
    this.changeDetectorRef.detectChanges();
  }
  ngOnInit() {
    this.dataservice.getData().subscribe(data => this.data = data);
    this.dataservice.getListGenreMusic().subscribe(listGenreMisic => this.listGenreMisic.push(listGenreMisic));
    this.dataservice.getListGenreTv().subscribe(listGenreTv => this.listGenreTv.push(listGenreTv));

   for (const musicGenre of this.data.GenreMusic) {
     if (this.listGenreMisic.includes(musicGenre)) {
        this.listGenreMusicForFront.push(musicGenre);
    }
}
    for (const tvGenre of this.data.GenreTv) {
     if (this.listGenreTv.includes(tvGenre)) {
        this.listGenreTvForFront.push(tvGenre);
    }
}
     for (const dataMusicGenre of this.data.GenreMusic) {
      this.dataGenreMusicForFront.push(dataMusicGenre.Name);
    }
     for (const dataTvGenre of this.data.GenreMusic) {
      this.dataGenreTvForFront.push(dataTvGenre.Name);
    }
  }
}
