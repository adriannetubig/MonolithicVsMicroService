import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthenticationsComponent } from './components/authentications/authentications.component';
import { InventoryItemsComponent } from './components/inventoryItems/inventoryItems.component';
import { InventoryItemsCreateComponent } from './components/inventoryItemsCreateUpdate/inventoryItemsCreate.component';
import { InventoryItemsUpdateComponent } from './components/inventoryItemsCreateUpdate/inventoryItemsUpdate.component';
import { OrderItemsComponent } from './components/orderItems/orderItems.component';
import { OrderItemsCreateComponent } from './components/orderItemsCreateUpdate/orderItemsCreate.component';
import { OrderItemsUpdateComponent } from './components/orderItemsCreateUpdate/orderItemsUpdate.component';


const routes: Routes = [
  { path: 'authentications', component: AuthenticationsComponent },
  { path: 'inventoryItems', component: InventoryItemsComponent },
  { path: 'inventoryItems/create', component: InventoryItemsCreateComponent },
  { path: 'inventoryItems/update/:inventoryItemId', component: InventoryItemsUpdateComponent },
  { path: 'orderItems', component: OrderItemsComponent },
  { path: 'orderItems/create', component: OrderItemsCreateComponent },
  { path: 'orderItems/update/:orderItemId', component: OrderItemsUpdateComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
