import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router"

import { OrderItemsService } from '../../services/orderItems.service';

import { OrderItem } from '../../shared/models/orderItem';

@Component({
  selector: 'app-orderItems',
  templateUrl: './orderItemsCreateUpdate.component.html',
})

export class OrderItemsCreateComponent implements OnInit {

  OrderItem: OrderItem;
  constructor(private _router: Router, private _orderItemsService: OrderItemsService) {
    this.OrderItem = {
      orderName: ''
    } as OrderItem;
  }

  ngOnInit() {
  }

  async submit() {
    await this._orderItemsService.create(this.OrderItem);
    this._router.navigate(['/orderItems']);
  }

}
