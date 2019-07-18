import { Component, OnInit } from '@angular/core';
import { LocalStorage } from '@ngx-pwa/local-storage';

import { AuthenticationsService } from '../../services/authentications.service';

import { Authentication } from '../../shared/models/authentication';
import { Login } from '../../shared/models/login';

@Component({
  selector: 'app-authentications',
  templateUrl: './authentications.component.html',
  styleUrls: ['./authentications.component.less']
})
export class AuthenticationsComponent implements OnInit {
  Login: Login;

  constructor(private _authenticationsService: AuthenticationsService, private _localStorage: LocalStorage) {
    this.Login = {
      username: '',
      password: ''
    } as Login;
  }

  ngOnInit() {
  }

  authenticate() {
    this._authenticationsService.authenticate(this.Login).subscribe(
      async result => {
        this._localStorage.setItem('Access', result).subscribe(() => { });
      }
    );
  }

}
