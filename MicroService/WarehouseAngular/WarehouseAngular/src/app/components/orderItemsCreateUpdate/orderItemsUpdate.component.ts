import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {Router} from "@angular/router"

import { OrderItemsService } from '../../services/orderItems.service';

import { OrderItem } from '../../shared/models/orderItem';

@Component({
  selector: 'app-orderItems',
  templateUrl: './orderItemsCreateUpdate.component.html',
})

export class OrderItemsUpdateComponent implements OnInit {

  OrderItem: OrderItem;
  constructor(private _activatedRoute: ActivatedRoute, private _router: Router, private _orderItemsService: OrderItemsService) {
    this.OrderItem = {
      orderName: ''
    } as OrderItem;
  }

  async ngOnInit() {
    this.OrderItem = await this._orderItemsService.readSingle(+this._activatedRoute.snapshot.paramMap.get('orderItemId'));
  }

  async submit() {
    await this._orderItemsService.update(this.OrderItem);
    this._router.navigate(['/orderItems']);
  }

}
