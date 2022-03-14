import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule} from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatCheckboxModule, MatToolbarModule, MatSidenavModule, MatIconModule,
   MatListModule, MAT_DATE_LOCALE } from '@angular/material';
import { MaterialModule } from './modules/material/material.module';
import { FileDropModule } from 'ngx-file-drop';

import { RecaptchaModule } from 'ng-recaptcha';
import { RecaptchaFormsModule } from 'ng-recaptcha/forms';
import { NgxSpinnerModule } from 'ngx-spinner';

import { UserService } from './shared/user.service';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { SignInComponent } from './user/sing-in/sing-in.component';
import { HomeComponent } from './home/home.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MainNavComponent } from './main-nav/main-nav.component';
import { LayoutModule } from '@angular/cdk/layout';
import { OverlayModule } from '@angular/cdk/overlay';
import { GlobalService } from './shared/global.service';
import { DatePipe } from '@angular/common';
import { RegisterComponent } from './user/register/register.component';
import { AdminNavComponent } from './admin-nav/admin-nav.component';
import { HrRegistrationComponent } from './hr-registration/hr-registration.component';
import { AdminService } from './shared/admin.service';
import { HrNavComponent } from './hr-nav/hr-nav.component';
import { HrHomeComponent } from './hr-home/hr-home.component';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AdminUsersComponent } from './admin-users/admin-users.component';
import { UserFormComponent } from './user-form/user-form.component';
import { HrUserFormComponent } from './hr-userform/hr-userform.component';
import { HrService } from './shared/hr.service';
import { HrUserFormFullComponent } from './hr-userformfull/hr-userformfull.component';
import { HrUserFormSeeComponent } from './hr-userform-see/hr-userform-see.component';
import { UserStatusComponent } from './user-status/user-status.component';
import { HrUserFormApproveComponent } from './hr-userform-approve/hr-userform-approve.component';
import { HrUserFormRejectComponent } from './hr-userform-reject/hr-userform-reject.component';
import { AdminProgLangComponent } from './admin-proglang/admin-proglang.component';
import { MainPageComponent } from './main-page/main-page.component';

import { DateTimeFormatPipe } from './pipes/date-time-format.pipe';
import { DateFormatPipe } from './pipes/date-format.pipe';
import { FilterPipe } from './pipes/filter.pipe';
import { HrFilterPipe } from './pipes/hr-filter.pipe';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    SignInComponent,
    RegisterComponent,
    HomeComponent,
    HrHomeComponent,
    AdminHomeComponent,
    AdminUsersComponent,
    AdminProgLangComponent,
    MainNavComponent,
    UserFormComponent,
    UserStatusComponent,

    DateTimeFormatPipe,
    DateFormatPipe,
    FilterPipe,
    HrFilterPipe,
    HrNavComponent,
    HrUserFormComponent,
    HrUserFormSeeComponent,
    HrUserFormApproveComponent,
    HrUserFormRejectComponent,
    HrUserFormFullComponent,
    AdminNavComponent,
    HrRegistrationComponent,
    MainPageComponent
  ],
  imports: [
    BrowserModule,
    MaterialModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    MatButtonModule,
    MatCheckboxModule,
    FileDropModule,
    RecaptchaModule,
    RecaptchaFormsModule,
    NgxSpinnerModule,
    LayoutModule,
    MatToolbarModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    OverlayModule
  ],
  providers: [
    { provide: MAT_DATE_LOCALE, useValue: 'ru-RU' },
    DatePipe,
    UserService,
    AdminService,
    HrService,
    GlobalService,
    ],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor() {}
}
