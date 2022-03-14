import { Component, OnInit } from '@angular/core';
import { UploadEvent, UploadFile, FileSystemFileEntry, FileSystemDirectoryEntry } from 'ngx-file-drop';
import { MatSnackBar, MatDialog } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { AdminService } from '../shared/admin.service';
import { ProgLang } from '../user-form/models/proglang.model';

@Component({
  selector: 'app-admin-proglang',
  templateUrl: './admin-proglang.component.html',
  styleUrls: ['./admin-proglang.component.css']
})
export class AdminProgLangComponent implements OnInit {
  public files: UploadFile[] = [];
  public proglang: ProgLang[] = [];

  isLoginError = false;
  newProglang: ProgLang = new ProgLang(null, '');
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
    this.getProgLangs();
  }

  OnSubmit(proglang: string) {
    this.newProglang.ProgLang = proglang;
    this.spinner.show();
    this.adminService.AddProgLang(this.newProglang).subscribe(next => {
      console.log(next)
      this.spinner.hide();
      if (next.error === false) {
        this.getProgLangs();
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

  getProgLangs() {
    this.adminService.getProgLangs().toPromise().then(
      data => {
        this.proglang = data;
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
    this.newProglang = new ProgLang(null, '');
  }
  
}
