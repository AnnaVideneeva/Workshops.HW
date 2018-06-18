import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

    constructor(private http: HttpClient) { }

    getPAymentEnabled(): Observable<boolean> {
        return this.http.get<boolean>(`http://rocket-api.belpyro.net/userpayments/paymentInfo`);
    }

}
