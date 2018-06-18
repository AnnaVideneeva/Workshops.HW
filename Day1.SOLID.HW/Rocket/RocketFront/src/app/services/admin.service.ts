import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Urls } from './../constants';

@Injectable()
export class AdminService{
    constructor(private http: HttpClient) {
    }

    getAllUsers(): Observable<any> {
        return this.http.get<any>(Urls.getAllUsers);
    }

    getAllRoles(): Observable<any> {
        return this.http.get<any>(Urls.getAllRoles);
    }
}
