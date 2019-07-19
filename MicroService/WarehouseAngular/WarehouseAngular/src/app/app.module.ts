import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthenticationsComponent } from './components/authentications/authentications.component';
import { InventoryItemsComponent } from './components/inventoryItems/inventoryItems.component';
import { InventoryItemsCreateComponent } from './components/inventoryItemsCreateUpdate/inventoryItemsCreate.component';
import { InventoryItemsUpdateComponent } from './components/inventoryItemsCreateUpdate/inventoryItemsUpdate.component';
import { OrderItemsComponent } from './components/orderItems/orderItems.component';
import { OrderItemsCreateComponent } from './components/orderItemsCreateUpdate/orderItemsCreate.component';
import { OrderItemsUpdateComponent } from './components/orderItemsCreateUpdate/orderItemsUpdate.component';

@NgModule({
  declarations: [
    AppComponent,
    AuthenticationsComponent,
    InventoryItemsComponent,
    InventoryItemsCreateComponent,
    InventoryItemsUpdateComponent,
    OrderItemsComponent,
    OrderItemsCreateComponent,
    OrderItemsUpdateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    HttpClientModule,
    HttpModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
