import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BehaviorSubject } from 'rxjs';
import {map} from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { User } from '../_models/User';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = environment.apiUrl;
  jwtHelper = new JwtHelperService();
  decodedToken: any;

  Hospital = new BehaviorSubject<string>('0');
  currentHospital = this.Hospital.asObservable();

  SerialNumber = new BehaviorSubject<string>('');
  currentSerial = this.SerialNumber.asObservable();

  UserRole = new BehaviorSubject<string>('');
  currentRole = this.UserRole.asObservable();


constructor(private http: HttpClient) { }

changeCurrentHospital(sh: string) { this.Hospital.next(sh); }
changeCurrentSerial(sh: string) { this.SerialNumber.next(sh); }
changeCurrentRole(sh: string) { this.UserRole.next(sh); }

login(model: any) {
    return this.http.post(this.baseUrl + 'auth/login', model).pipe(
        map((response: any) => {
            const r = response;
            
                localStorage.setItem('token', r.token);
                this.decodedToken = this.jwtHelper.decodeToken(r.token);
                console.log(this.decodedToken);
            
        })
    );
}

register(model: any) { return this.http.post(this.baseUrl + 'auth/register', model); }

updatePassword(model: any) { return this.http.put(this.baseUrl + 'auth/changePassword', model); }

loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
}

}
