import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {Router} from "@angular/router"

import { InventoryItemsService } from '../../services/inventoryItems.service';

import { InventoryItem } from '../../shared/models/inventoryItem';

@Component({
  selector: 'app-inventoryItems',
  templateUrl: './inventoryItemsCreateUpdate.component.html',
})

export class InventoryItemsUpdateComponent implements OnInit {

  InventoryItem: InventoryItem;
  constructor(private _activatedRoute: ActivatedRoute, private _router: Router, private _inventoryItemsService: InventoryItemsService) {
    this.InventoryItem = {
      inventoryName: ''
    } as InventoryItem;
  }

  async ngOnInit() {
    this.InventoryItem = await this._inventoryItemsService.readSingle(+this._activatedRoute.snapshot.paramMap.get('inventoryItemId'));
  }

  async submit() {
    await this._inventoryItemsService.update(this.InventoryItem);
    this._router.navigate(['/inventoryItems']);
  }

}
