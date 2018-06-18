import { Injectable } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { Subject } from 'rxjs';
import { debug } from 'util';
import {Router} from '@angular/router';

@Injectable()
export class RocketAuthService {
  authSubj = new Subject<boolean>(); // subscribe inside another components

  constructor(private openId: OAuthService, private router: Router) { }

  login(username: string, password: string) {
    if (this.IsAuthenticated) {
      this.openId.logOut();
      this.authSubj.next(false);      
    }    

    this.openId.fetchTokenUsingPasswordFlow(username, password)
      .then(result => {
        this.authSubj.next(true);
        this.openId.loadUserProfile().then(res => console.log(res));
        this.router.navigateByUrl('/');
      })
      .catch(ex => console.log(ex));
      
  }

  logoff() {  
      this.openId.logOut(); 
      this.router.navigateByUrl('/login');   
  }

  get IsAuthenticated(): boolean {
    // add token actual date
    return this.openId.getAccessToken() != null
      && this.openId.getAccessTokenExpiration() > Date.now();
  }
}
