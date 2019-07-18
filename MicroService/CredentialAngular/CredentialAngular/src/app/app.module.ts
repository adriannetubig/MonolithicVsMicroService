import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthenticationsComponent } from './components/authentications/authentications.component';
import { LoginsComponent } from './components/logins/logins.component';
import { loginsCreateComponent } from './components/loginsCreateUpdate/loginsCreate.component';
import { loginsUpdateComponent } from './components/loginsCreateUpdate/loginsUpdate.component';


@NgModule({
  declarations: [
    AppComponent,
    AuthenticationsComponent,
    LoginsComponent,
    loginsCreateComponent,
    loginsUpdateComponent
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
