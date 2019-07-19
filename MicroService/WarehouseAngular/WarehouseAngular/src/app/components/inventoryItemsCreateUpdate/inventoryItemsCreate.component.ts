import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router"

import { InventoryItemsService } from '../../services/inventoryItems.service';

import { InventoryItem } from '../../shared/models/inventoryItem';

@Component({
  selector: 'app-inventoryItems',
  templateUrl: './inventoryItemsCreateUpdate.component.html',
})

export class InventoryItemsCreateComponent implements OnInit {

  InventoryItem: InventoryItem;
  constructor(private _router: Router, private _inventoryItemsService: InventoryItemsService) {
    this.InventoryItem = {
      inventoryName: ''
    } as InventoryItem;
  }

  ngOnInit() {
  }

  async submit() {
    await this._inventoryItemsService.create(this.InventoryItem);
    this._router.navigate(['/inventoryItems']);
  }

}
