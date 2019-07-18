import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LocalStorage } from '@ngx-pwa/local-storage';
import { HttpHeaders } from '@angular/common/http';

import { environment } from '../../environments/environment';

import { Authentication } from '../shared/models/authentication';
import { Login } from '../shared/models/login';

@Injectable({
  providedIn: 'root'
})
export class LoginsService {

  constructor(private http: HttpClient, private _localStorage: LocalStorage) {
  }

  async create(login: Login) {
    return this.http.put<Login[]>(environment.url + '/api/Logins', login, await this.getHttpOptions()).toPromise().then();
  }

  async readSingle(loginId: number) {
    return this.http.get<Login>(environment.url + '/api/Logins/' + loginId, await this.getHttpOptions()).toPromise().then();
  }

  async read() {
    return this.http.get<Login[]>(environment.url + '/api/Logins', await this.getHttpOptions()).toPromise().then();
  }

  async update(login: Login) {
    return this.http.post<Login[]>(environment.url + '/api/Logins', login, await this.getHttpOptions()).toPromise().then();
  }

  async delete(loginId: number) {
    return this.http.delete<Login[]>(environment.url + '/api/Logins/' + loginId, await this.getHttpOptions()).toPromise().then();
  }

  private async getToken() {
    var authentication = await this._localStorage.getItem('Access').toPromise().then<Authentication>();
    return authentication.token;
  }
  
  private async getHttpOptions() {
    return {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        'Authorization': 'bearer ' + await this.getToken()
      })
    };
  }
}