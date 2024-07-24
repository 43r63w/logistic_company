import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from '../models/login';
import { environment } from '../../environments/environment.development';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  public IsUserAuth = new BehaviorSubject<boolean>(false);

  constructor(private _httpClient: HttpClient) {}

  login(login: Login) {
    return this._httpClient.post<Login>(
      `${environment.apiUrl}/api/user/login-user`,
      login
    );
  }

  isLoggedIn(): boolean {
    if (localStorage.getItem('token')) return true;

    return false;
  }

  login1(){
     this.IsUserAuth.next(true)
  }

}
