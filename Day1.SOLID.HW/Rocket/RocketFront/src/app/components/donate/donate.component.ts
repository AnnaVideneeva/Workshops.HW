import { Component, OnInit } from '@angular/core';
import { PaymentService } from '../../services/payment.service';
import { ActivatedRoute, Router } from '@angular/router';
import { OAuthService } from 'angular-oauth2-oidc';
import { RocketAuthService } from '../../services/auth.service';

@Component({
  selector: 'app-donate',
  templateUrl: './donate.component.html',
  styleUrls: ['./donate.component.css']
})
export class DonateComponent implements OnInit {

  paymentEnabled: boolean;

  constructor(private paymentService: PaymentService, private auth: RocketAuthService) { }

  ngOnInit() {
    this.getPAymentEnabled();
  }

  getPAymentEnabled() {
    this.paymentService.getPAymentEnabled()
      .subscribe(data => {
        this.paymentEnabled = data;
      });
  }

  login() {
    this.auth.login('firstUser', 'password');
  }

}
