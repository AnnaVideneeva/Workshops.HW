import { Component, OnInit } from '@angular/core';
import { UserRegister } from '../../models/personal-area/user-register';
import { UserRegisterService } from '../../services/user-register.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  User = new UserRegister();

  constructor(private userRegService: UserRegisterService) { }

  ngOnInit() {
  }

  register() {
    this.userRegService.register(this.User).subscribe();
  }

}
