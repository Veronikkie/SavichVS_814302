import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { UserComponent } from './user/user.component';
import { SignInComponent } from './user/sing-in/sing-in.component';
import { RegisterComponent } from './user/register/register.component';
import { HrRegistrationComponent } from './hr-registration/hr-registration.component';
import { HrHomeComponent } from './hr-home/hr-home.component';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AdminUsersComponent } from './admin-users/admin-users.component';
import { UserFormComponent } from './user-form/user-form.component';
import { HrUserFormComponent } from './hr-userform/hr-userform.component';
import { HrUserFormFullComponent } from './hr-userformfull/hr-userformfull.component';
import { HrUserFormSeeComponent } from './hr-userform-see/hr-userform-see.component';
import { UserStatusComponent } from './user-status/user-status.component';
import { HrUserFormApproveComponent } from './hr-userform-approve/hr-userform-approve.component';
import { HrUserFormRejectComponent } from './hr-userform-reject/hr-userform-reject.component';
import { AdminProgLangComponent } from './admin-proglang/admin-proglang.component';
import { MainPageComponent } from './main-page/main-page.component';

const routes: Routes = [
  { path : '', redirectTo: '/main-page', pathMatch : 'full'},
  { path: 'main-page', component: MainPageComponent },
  { path: 'home', component: HomeComponent },
  { path: 'hr-home', component: HrHomeComponent },
  { path: 'hr-userform', component: HrUserFormComponent },
  { path: 'hr-userform-see', component: HrUserFormSeeComponent },
  { path: 'hr-userformfull', component: HrUserFormFullComponent },
  { path: 'hr-userform-approve', component: HrUserFormApproveComponent },
  { path: 'hr-userform-reject', component: HrUserFormRejectComponent },
  { path: 'admin-home', component: AdminHomeComponent },
  { path: 'admin-users', component: AdminUsersComponent },
  { path: 'admin-proglang', component: AdminProgLangComponent },
  { path: 'status', component: UserStatusComponent },

  { path: 'hr-registration', component: HrRegistrationComponent },
  { path: 'login', component: UserComponent, children: [{ path: '', component: SignInComponent }]},
  { path: 'login', component: UserComponent, pathMatch: 'full' },
  { path: 'registration', component: RegisterComponent, pathMatch: 'full' },
  { path: 'user-form', component: UserFormComponent },
  { path: '**', redirectTo: '/main-page'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
