import { Component, OnInit } from '@angular/core';
import { OrderItem } from '../../shared/models/orderItem';

import { OrderItemsService } from '../../services/orderItems.service';

@Component({
  selector: 'app-orderItems',
  templateUrl: './orderItems.component.html',
  styleUrls: ['./orderItems.component.less']
})
export class OrderItemsComponent implements OnInit {

  OrderItems: OrderItem[];
  constructor(private _orderItemsService: OrderItemsService) { }

  async ngOnInit() {
    this.OrderItems = await this._orderItemsService.read().then();
  }

  async delete(orderItemId: number) {
    await this._orderItemsService.delete(orderItemId).then();
    this.OrderItems = await this._orderItemsService.read().then();
  }

}
