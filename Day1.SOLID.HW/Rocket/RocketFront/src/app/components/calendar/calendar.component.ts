import { Component, ChangeDetectionStrategy, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { registerLocaleData } from '@angular/common';
import localeRu from '@angular/common/locales/ru';
import { CalendarEvent, CalendarDateFormatter, DAYS_OF_WEEK } from 'angular-calendar';
import {
  isSameMonth,
  isSameDay,
  startOfMonth,
  endOfMonth,
  startOfWeek,
  endOfWeek,
  startOfDay,
  endOfDay,
  format
} from 'date-fns';
import { Observable } from 'rxjs';
import { colors } from './calendar-utils/colors';
import { Router } from '@angular/router';
import { CustomDateFormatter } from './custom-date-formatter.provider';
import { Urls } from '../../constants';

registerLocaleData(localeRu);

interface ReleaseFilms {
  id: number;
  title: string;
  release_date: string;
}

interface ReleaseMusic {
  Id: number;
  Title: string;
  ReleaseDate: string;
  Artist: string;
}

interface ReleaseSeries {
  Id: number;
  TvSeriesTitleRu: string;
  TitleRu: string;
  ReleaseDateRu: string;
}

interface Release
{}

interface ReleaseEvent
{
  id: number;
  UrlForEpisodeSource: string;
  TvSeriesId: number;
  Id: number;
}

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
  styleUrls: ['./calendar.component.css'],
  providers: [
    {
      provide: CalendarDateFormatter,
      useClass: CustomDateFormatter
    }
  ]
})
export class CalendarComponent implements OnInit {

  view: string = 'month';
  nameCalendar: string;
  targetMethod: number;

  locale: string = 'ru';

  weekStartsOn: number = DAYS_OF_WEEK.MONDAY;

  weekendDays: number[] = [DAYS_OF_WEEK.SATURDAY, DAYS_OF_WEEK.SUNDAY];

  viewDate: Date = new Date();
  events$: Observable<Array<CalendarEvent<{ release: Release }>>>;
  activeDayIsOpen: boolean = false;

  constructor(private http: HttpClient, private router: Router) {}

  ngOnInit(): void {
    this.filmsEvents();
  }

  filmsEvents(): void {
    this.nameCalendar = "Фильмы"
    this.targetMethod = 1;

    const getStart: any = {
      month: startOfMonth,
      week: startOfWeek,
      day: startOfDay
    }[this.view];

    const getEnd: any = {
      month: endOfMonth,
      week: endOfWeek,
      day: endOfDay
    }[this.view];

    const params = new HttpParams()
      .set(
        'primary_release_date.gte',
        format(getStart(this.viewDate), 'YYYY-MM-DD')
      )
      .set(
        'primary_release_date.lte',
        format(getEnd(this.viewDate), 'YYYY-MM-DD')
      )
      .set('api_key', '0ec33936a68018857d727958dca1424f');

    this.events$ = this.http
      .get('https://api.themoviedb.org/3/discover/movie', { params })
      .pipe(
        map(({ results }: { results: ReleaseFilms[] }) => {
          return results.map((release: ReleaseFilms) => {
            return {
              title: release.title,
              start: new Date(release.release_date),
              color: colors.yellow,
              meta: {
                release
              }
            };
          });
        })
      );
  }

  dayClicked({
    date,
    events
  }: {
    date: Date;
    events: Array<CalendarEvent<{ release: ReleaseFilms }>>;
  }): void {
    if (isSameMonth(date, this.viewDate)) {
      if (
        (isSameDay(this.viewDate, date) && this.activeDayIsOpen === true) ||
        events.length === 0
      ) {
        this.activeDayIsOpen = false;
      } else {
        this.activeDayIsOpen = true;
        this.viewDate = date;
      }
    }
  }

  eventClicked(event: CalendarEvent<{ release: ReleaseEvent }>): void {

    if(this.targetMethod==1){
      window.open(
        `https://www.themoviedb.org/movie/${event.meta.release.id}`,
        '_blank'
      );
    }
    else if(this.targetMethod==2){
      this.router.navigate([`series/${event.meta.release.TvSeriesId}`]);
    }
    else if(this.targetMethod==3){
      this.router.navigate([`music/${event.meta.release.Id}`]);
    }

  }

  seriesEvents(): void {
    this.nameCalendar = "Сериалы"
    this.targetMethod = 2;

    const getStart: any = {
      month: startOfMonth,
      week: startOfWeek,
      day: startOfDay
    }[this.view];
    const getEnd: any = {
      month: endOfMonth,
      week: endOfWeek,
      day: endOfDay
    }[this.view];

    const params = new HttpParams()
      .set(
        'start_date',
        format(getStart(this.viewDate), 'YYYY-MM-DD')
      )
      .set(
        'end_date',
        format(getEnd(this.viewDate), 'YYYY-MM-DD')
      )

    this.events$ = this.http
      .get(`${Urls.newsApiUrl}/episode/calendar`, { params })
      .pipe(
        map(( results: ReleaseSeries[] ) => {
          return results.map((release: ReleaseSeries) => {
            return {
              title: release.TvSeriesTitleRu  + " - " + release.TitleRu,
              start: new Date(release.ReleaseDateRu),
              color: colors.yellow,
              meta: {
                release
              }
            };
          });
        })
      );
  }

  musicEvents(): void {
    this.nameCalendar = "Музыка"
    this.targetMethod = 3;

    const getStart: any = {
      month: startOfMonth,
      week: startOfWeek,
      day: startOfDay
    }[this.view];
    const getEnd: any = {
      month: endOfMonth,
      week: endOfWeek,
      day: endOfDay
    }[this.view];

    const params = new HttpParams()
      .set(
        'start_date',
        format(getStart(this.viewDate), 'YYYY-MM-DD')
      )
      .set(
        'end_date',
        format(getEnd(this.viewDate), 'YYYY-MM-DD')
      )

    this.events$ = this.http
      .get(`${Urls.newsApiUrl}/music/calendar`, { params })
      .pipe(
        map(( results: ReleaseMusic[] ) => {
          return results.map((release: ReleaseMusic) => {
            return {
              title: release.Artist + " - " + release.Title,
              start: new Date(release.ReleaseDate),
              color: colors.yellow,
              meta: {
                release
              }
            };
          });
        })
      );
  }

  releaseEvents(): void{
      if(this.targetMethod==1){
        this.filmsEvents();
      }
      else if(this.targetMethod==2){
        this.seriesEvents();
      }
      else if(this.targetMethod==3)
      {
        this.musicEvents();
      }
  }
}
