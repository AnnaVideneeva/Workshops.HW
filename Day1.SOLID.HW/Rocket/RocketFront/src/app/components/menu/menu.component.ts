import { Component, OnInit } from '@angular/core';
import { RocketAuthService } from '../../services/auth.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent {

  constructor(private rocketAuthService: RocketAuthService) { }

  public logoff() {
    this.rocketAuthService.logoff();
}

}
