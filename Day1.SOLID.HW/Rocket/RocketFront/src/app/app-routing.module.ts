import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from './components/login/login.component';
import { AdminComponent } from './components/admin/admin.component';
import { DonateComponent } from './components/donate/donate.component';
import { NewsFeedComponent } from './components/news-feed/news-feed.component';
import { PersonalAreaComponent } from './components/personal-area/personal-area.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { CalendarComponent } from './components/calendar/calendar.component';
import { EpisodesComponent } from './components/news-feed/episodes/episodes.component';
import { MusicsComponent } from './components/news-feed/musics/musics.component';
import { SeriesDetailsComponent } from './components/news-feed/series-details/series-details.component';
import { SeriesCatalogComponent } from './components/catalog/series-catalog/series-catalog.component';
import { CatalogComponent } from './components/catalog/catalog.component';
import { MusicCatalogComponent } from './components/catalog/music-catalog/music-catalog.component';
import { MusicsDetailsComponent } from './components/news-feed/musics-details/musics-details.component';
import { RocketAuthGuard } from './auth.guard';


const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'admin', component: AdminComponent
  // , canActivate: [RocketAuthGuard]
},
  { path: 'donate', component: DonateComponent },
  {
    path: 'news',
    component: NewsFeedComponent,
    children: [
      { path: '', redirectTo: 'series', pathMatch: 'prefix' },
      { path: 'series', component: EpisodesComponent },
      { path: 'music', component: MusicsComponent }
    ]
  },
  { path: 'series/:id', component: SeriesDetailsComponent },
  { path: 'music/:id', component: MusicsDetailsComponent },
  {
    path: 'catalog',
    component: CatalogComponent,
    children: [
      { path: '', redirectTo: 'series', pathMatch: 'prefix' },
      { path: 'series', component: SeriesCatalogComponent },
      { path: 'music', component: MusicCatalogComponent }
    ]
  },
  { path: 'personal', component: PersonalAreaComponent}, // , canActivate: [RocketAuthGuard] },
  { path: 'registration', component: RegistrationComponent },
  { path: 'calendar', component: CalendarComponent },
  { path: '', redirectTo: 'catalog', pathMatch: 'full' },
  { path: '**', redirectTo: '' }
  // добавить путь для ошибки, обычные пути
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
