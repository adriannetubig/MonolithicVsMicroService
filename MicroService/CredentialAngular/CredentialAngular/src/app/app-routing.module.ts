import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthenticationsComponent } from './authentications/authentications.component';
import { LoginsComponent } from './logins/logins.component';
import { loginsCreateComponent } from './logins/loginsCreate.component';



const routes: Routes = [
  { path: 'authentications', component: AuthenticationsComponent },
  { path: 'logins', component: LoginsComponent },
  { path: 'logins/create', component: loginsCreateComponent }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
