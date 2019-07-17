import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from './../../environments/environment';

import { Authentication } from '../shared/models/authentication';
import { Login } from '../shared/models/login';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationsService {

  constructor(private http: HttpClient) {
  }

  authenticate(login: Login) {
    return this.http.post<Authentication>(environment.url + '/api/Authentications', login);
  }
}
