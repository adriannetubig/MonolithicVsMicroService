import { Component, OnInit } from '@angular/core';
import { InventoryItem } from '../../shared/models/inventoryItem';

import { InventoryItemsService } from '../../services/inventoryItems.service';

@Component({
  selector: 'app-inventoryItems',
  templateUrl: './inventoryItems.component.html',
  styleUrls: ['./inventoryItems.component.less']
})
export class InventoryItemsComponent implements OnInit {

  InventoryItems: InventoryItem[];
  constructor(private _inventoryItemsService: InventoryItemsService) { }

  async ngOnInit() {
    this.InventoryItems = await this._inventoryItemsService.read().then();
  }

  async delete(inventoryItemId: number) {
    await this._inventoryItemsService.delete(inventoryItemId).then();
    this.InventoryItems = await this._inventoryItemsService.read().then();
  }

}
