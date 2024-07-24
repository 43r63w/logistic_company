import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from '../models/login';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private _httpClient: HttpClient) {}

  login(login:Login) {
    return this._httpClient.post<Login>(`${environment.apiUrl}/api/user/login-user`,login)
  }

  

}
