import { Component, OnInit } from '@angular/core';
import { UserService, Config } from '../../shared/user.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RecaptchaFormsModule } from 'ng-recaptcha/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { GlobalService } from 'src/app/shared/global.service';

@Component({
  selector: 'app-sing-in',
  templateUrl: './sing-in.component.html',
  styleUrls: ['./sing-in.component.css']
})
export class SignInComponent implements OnInit {

  constructor(
    private userService: UserService,
    private router: Router,
    private spinner: NgxSpinnerService,
    private globalService: GlobalService) { }

  ngOnInit() {

  }

  OnSubmit(userName: string, password: string) {
    this.spinner.show();
    this.userService.userAuthentication(userName, password).subscribe((data: any) => {
      if (data == 0) {
        alert('Wrong login or password');
        this.spinner.hide();
      } else {
        localStorage.setItem('role', data.Role.RoleName);
        localStorage.setItem('userName', data.UserName);
        localStorage.setItem('email', data.Email);
        localStorage.setItem('userId', data.Id);

        if (data.Role.RoleName == "User") {
          this.router.navigate(['/home']);
        }

        if (data.Role.RoleName == "Admin") {
          this.router.navigate(['/admin-home']);
        }

        if (data.Role.RoleName == "HR") {
          this.router.navigate(['/hr-home']);
        }

      }
    })
  }

  Register() {
    this.router.navigate(['/registration']);
  }
}
