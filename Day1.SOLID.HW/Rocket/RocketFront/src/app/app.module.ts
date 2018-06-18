import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './components/app/app.component';
import { LoginComponent } from './components/login/login.component';
import { SignalRComponent } from './components/signalR/signalr.component';

import { AppRoutingModule } from './app-routing.module';
import { MenuComponent } from './components/menu/menu.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { NotificationComponent } from './components/notification/notification.component';
import { AdminComponent } from './components/admin/admin.component';
import { PaymentComponent } from './components/payment/payment.component';
import { DonateComponent } from './components/donate/donate.component';
import { NewsFeedComponent } from './components/news-feed/news-feed.component';
import { PersonalAreaComponent } from './components/personal-area/personal-area.component';
import { SignalRModule } from 'ng2-signalr';
import { SignalRConfiguration } from 'ng2-signalr';
import { SnotifyModule, SnotifyService, ToastDefaults } from 'ng-snotify';
import { CalendarComponent } from './components/calendar/calendar.component';
import { EpisodesComponent } from './components/news-feed/episodes/episodes.component';
import { PagingComponent } from './components/news-feed/paging/paging.component';
import { MusicsComponent } from './components/news-feed/musics/musics.component';
import { SeriesDetailsComponent } from './components/news-feed/series-details/series-details.component';
import { SeriesCatalogComponent } from './components/catalog/series-catalog/series-catalog.component';
import { CatalogComponent } from './components/catalog/catalog.component';
import { MusicCatalogComponent } from './components/catalog/music-catalog/music-catalog.component';
import { GenresComponent } from './components/catalog/genres/genres.component';

import { CalendarModule } from 'angular-calendar';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CalendarUtilsModule } from './components/calendar/calendar-utils/module';
import { Urls } from './constants';
import { MusicsDetailsComponent } from './components/news-feed/musics-details/musics-details.component';
import { AdvertisementComponent } from './components/common/advertisement/advertisement.component';
import { SideMenuComponent } from './components/common/side-menu/side-menu.component';
import { OAuthModule } from 'angular-oauth2-oidc';
import { RocketAuthService } from './services/auth.service';
import { AdminService } from './services/admin.service';

export function createConfig(): SignalRConfiguration {
  const c = new SignalRConfiguration();
  c.hubName = 'Notification';
  c.url = Urls.signalRUrl;
  c.logging = true;
  return c;
}


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignalRComponent,
    MenuComponent,
    RegistrationComponent,
    NotificationComponent,
    AdminComponent,
    PaymentComponent,
    DonateComponent,
    NewsFeedComponent,
    PersonalAreaComponent,
    CalendarComponent,
    EpisodesComponent,
    PagingComponent,
    MusicsComponent,
    SeriesDetailsComponent,
    SeriesCatalogComponent,
    CatalogComponent,
    SeriesCatalogComponent,
    MusicCatalogComponent,
    GenresComponent,
    MusicsDetailsComponent,
    AdvertisementComponent,
    SideMenuComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    OAuthModule.forRoot({
      resourceServer: {
        allowedUrls: ['http://rocket-api.belpyro.net'],
        sendAccessToken: true
      }
    }),
    SignalRModule.forRoot(createConfig),
    BrowserAnimationsModule,
    CalendarModule.forRoot(),
    CalendarUtilsModule,
    SnotifyModule
  ],
  providers: [{ provide: 'SnotifyToastConfig', useValue: ToastDefaults }, SnotifyService, RocketAuthService, AdminService],
  bootstrap: [AppComponent]
})
export class AppModule { }
