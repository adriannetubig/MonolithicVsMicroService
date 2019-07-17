import { Component, OnInit } from '@angular/core';
import { Login } from '../shared/models/login';

import { LoginsService } from './logins.service';

@Component({
  selector: 'app-logins',
  templateUrl: './logins.component.html',
  styleUrls: ['./logins.component.less']
})
export class LoginsComponent implements OnInit {

  Logins: Login[];
  constructor(private _loginsService: LoginsService) { }

  async ngOnInit() {
    this.Logins = await this._loginsService.read().then();
  }

}
