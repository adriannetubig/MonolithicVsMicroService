import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthenticationsComponent } from './components/authentications/authentications.component';
import { LoginsComponent } from './components/logins/logins.component';
import { loginsCreateComponent } from './components/loginsCreateUpdate/loginsCreate.component';
import { loginsUpdateComponent } from './components/loginsCreateUpdate/loginsUpdate.component';



const routes: Routes = [
  { path: 'authentications', component: AuthenticationsComponent },
  { path: 'logins', component: LoginsComponent },
  { path: 'logins/create', component: loginsCreateComponent },
  { path: 'logins/update/:loginId', component: loginsUpdateComponent }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
