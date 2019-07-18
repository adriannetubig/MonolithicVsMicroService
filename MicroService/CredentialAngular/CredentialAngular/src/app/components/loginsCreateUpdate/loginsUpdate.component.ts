import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {Router} from "@angular/router"

import { LoginsService } from '../../services/logins.service';

import { Login } from '../../shared/models/login';

@Component({
  selector: 'app-logins',
  templateUrl: './loginsCreateUpdate.component.html',
})

export class loginsUpdateComponent implements OnInit {

  Login: Login;
  constructor(private _activatedRoute: ActivatedRoute, private _router: Router, private _loginsService: LoginsService) {
    this.Login = {
      username: '',
      password: ''
    } as Login;
  }

  async ngOnInit() {
    this.Login = await this._loginsService.readSingle(+this._activatedRoute.snapshot.paramMap.get('loginId'));
  }

  async submit() {
    await this._loginsService.update(this.Login);
    this._router.navigate(['/logins']);
  }

}
