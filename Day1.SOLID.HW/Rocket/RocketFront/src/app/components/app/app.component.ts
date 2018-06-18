import { Component } from '@angular/core';
import { OAuthService, AuthConfig, JwksValidationHandler } from 'angular-oauth2-oidc';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';

  constructor(private oidServ: OAuthService) {
    this.ConfigureOAuth();
  }

  private ConfigureOAuth() {
    this.oidServ.configure(authConfig);
    this.oidServ.tokenValidationHandler = new JwksValidationHandler();
    this.oidServ.loadDiscoveryDocument();
  }
}

export const authConfig: AuthConfig = {
  issuer: 'http://rocket-api.belpyro.net',
  showDebugInformation: true, // remove after debug
  clientId: 'client',
  dummyClientSecret: 'secret-rocket',
  scope: 'openid profile all_claims api',
  oidc: false,
  requireHttps: false
};
