import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserRegister } from '../models/personal-area/user-register';
import { Urls } from '../constants';
import { Observable } from 'rxjs/Observable';

@Injectable({
  providedIn: 'root'
})
export class UserRegisterService {

constructor(private http: HttpClient) { }

register(user: UserRegister): Observable<any> {
  return this.http.post<any>(`${Urls.newsApiUrl}/users/add`, user);
}

}
