import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LocalStorage } from '@ngx-pwa/local-storage';
import { HttpHeaders } from '@angular/common/http';

import { environment } from '../../environments/environment';

import { Authentication } from '../shared/models/authentication';
import { OrderItem } from '../shared/models/orderItem';

@Injectable({
  providedIn: 'root'
})
export class OrderItemsService {

  constructor(private http: HttpClient, private _localStorage: LocalStorage) {
  }

  async create(orderItem: OrderItem) {
    return this.http.put<OrderItem[]>(environment.url + '/api/OrderItems', orderItem, await this.getHttpOptions()).toPromise().then();
  }

  async readSingle(orderItemId: number) {
    return this.http.get<OrderItem>(environment.url + '/api/OrderItems/' + orderItemId, await this.getHttpOptions()).toPromise().then();
  }

  async read() {
    return this.http.get<OrderItem[]>(environment.url + '/api/OrderItems', await this.getHttpOptions()).toPromise().then();
  }

  async update(orderItem: OrderItem) {
    return this.http.post<OrderItem[]>(environment.url + '/api/OrderItems', orderItem, await this.getHttpOptions()).toPromise().then();
  }

  async delete(orderItemId: number) {
    return this.http.delete<OrderItem[]>(environment.url + '/api/OrderItems/' + orderItemId, await this.getHttpOptions()).toPromise().then();
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