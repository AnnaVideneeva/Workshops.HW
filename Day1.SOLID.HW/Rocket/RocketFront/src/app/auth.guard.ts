import { Injectable } from '@angular/core';
import { CanActivateChild, ActivatedRouteSnapshot, RouterStateSnapshot, CanActivate } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { RocketAuthService } from './services/auth.service';

@Injectable()
export class RocketAuthGuard implements CanActivate {

  constructor(private auth: RocketAuthService) {
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    return this.auth.IsAuthenticated;
  }
}
