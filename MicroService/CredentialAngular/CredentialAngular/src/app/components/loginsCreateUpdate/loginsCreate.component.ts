import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router"

import { LoginsService } from '../../services/logins.service';

import { Login } from '../../shared/models/login';

@Component({
  selector: 'app-logins',
  templateUrl: './loginsCreateUpdate.component.html',
})

export class loginsCreateComponent implements OnInit {

  Login: Login;
  constructor(private _router: Router, private _loginsService: LoginsService) {
    this.Login = {
      username: '',
      password: ''
    } as Login;
  }

  ngOnInit() {
  }

  async submit() {
    await this._loginsService.create(this.Login);
    this._router.navigate(['/logins']);
  }

}
