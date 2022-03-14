import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UploadEvent, UploadFile, FileSystemFileEntry, FileSystemDirectoryEntry } from 'ngx-file-drop';
import { MatSnackBar, MatDialog } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { DatePipe } from '@angular/common';
import { AdminService } from '../shared/admin.service';
import { UserReg } from '../shared/user.model';

@Component({
  selector: 'app-hr-registration',
  templateUrl: './hr-registration.component.html',
  styleUrls: ['./hr-registration.component.css']
})
export class HrRegistrationComponent implements OnInit {
  public files: UploadFile[] = [];

  isLoginError = false;
  newUser: UserReg = new UserReg('', '', '', '', '', '', '', '','');
  successMessage = 'Success';
  errorMessage = 'Error';
  successStyle = 'success-snackbar';
  errorStyle = 'error-snackbar';

  constructor(
    private adminService: AdminService,
    private router: Router,
    public snackBar: MatSnackBar,
    public dialog: MatDialog,
    public spinner: NgxSpinnerService
  ) { }

  ngOnInit() {

  }
  OnSubmit() {
    this.spinner.show();
    this.adminService.HrRegistration(this.newUser).subscribe(next => {
      console.log(next)
      this.spinner.hide();
      if (next.error === false) {
        this.showSnackBar(this.successMessage, this.successStyle);
        this.setObjectsToDefault();
      } else {
          this.showSnackBar(this.errorMessage, this.errorStyle); 
      }
    }, error => {
      console.log(error);
      this.spinner.hide();
    });
  }
  showSnackBar(message: string, typeClass: string) {
    this.snackBar.open(message, null, {
      duration: 3000,
      verticalPosition: 'top',
      horizontalPosition: 'center',
      panelClass: [typeClass]
    });
  }

  setObjectsToDefault() {
    this.newUser = new UserReg('', '', '', '', '', '', '', '','');
  }
  
}
