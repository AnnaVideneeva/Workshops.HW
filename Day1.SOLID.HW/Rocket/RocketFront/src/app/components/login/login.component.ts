import { Component, OnInit } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { RocketAuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  userLogin: string;
  password: string;

  constructor(private oauthService: OAuthService,
    private rocketAuthService: RocketAuthService) {
  }

  public login() {
      this.rocketAuthService.login(this.userLogin, this.password);
  }

  get givenName() {
    const claims = this.oauthService.getIdentityClaims();
    if (!claims) {
      return null;
    }
    return claims['name'];
  }
}
