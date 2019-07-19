import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LocalStorage } from '@ngx-pwa/local-storage';
import { HttpHeaders } from '@angular/common/http';

import { environment } from '../../environments/environment';

import { Authentication } from '../shared/models/authentication';
import { InventoryItem } from '../shared/models/inventoryItem';

@Injectable({
  providedIn: 'root'
})
export class InventoryItemsService {

  constructor(private http: HttpClient, private _localStorage: LocalStorage) {
  }

  async create(inventoryItem: InventoryItem) {
    return this.http.put<InventoryItem[]>(environment.url + '/api/InventoryItems', inventoryItem, await this.getHttpOptions()).toPromise().then();
  }

  async readSingle(inventoryItemId: number) {
    return this.http.get<InventoryItem>(environment.url + '/api/InventoryItems/' + inventoryItemId, await this.getHttpOptions()).toPromise().then();
  }

  async read() {
    return this.http.get<InventoryItem[]>(environment.url + '/api/InventoryItems', await this.getHttpOptions()).toPromise().then();
  }

  async update(inventoryItem: InventoryItem) {
    return this.http.post<InventoryItem[]>(environment.url + '/api/InventoryItems', inventoryItem, await this.getHttpOptions()).toPromise().then();
  }

  async delete(inventoryItemId: number) {
    return this.http.delete<InventoryItem[]>(environment.url + '/api/InventoryItems/' + inventoryItemId, await this.getHttpOptions()).toPromise().then();
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