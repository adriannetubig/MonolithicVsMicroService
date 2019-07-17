import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthenticationsComponent } from './authentications/authentications.component';
import { LoginsComponent } from './logins/logins.component';



const routes: Routes = [
  { path: 'authentications', component: AuthenticationsComponent },
  { path: 'logins', component: LoginsComponent }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
