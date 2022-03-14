import { Component, OnInit } from '@angular/core';
import { UploadEvent, UploadFile, FileSystemFileEntry, FileSystemDirectoryEntry } from 'ngx-file-drop';
import { MatSnackBar, MatDialog, Sort } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { PersonalInfo } from '../user-form/models/personalInfo.model';
import { HrService } from '../shared/hr.service';

@Component({
  selector: 'app-hr-userform',
  templateUrl: './hr-userform.component.html',
  styleUrls: ['./hr-userform.component.css']
})
export class HrUserFormComponent implements OnInit {
  public users: PersonalInfo[] = [];
  public sortedData: PersonalInfo[] = [];

  info: PersonalInfo = new PersonalInfo(null, '', '', '', '', '', '', '', '', '', null, null, '', '');

  constructor(
    private hrService: HrService,
    private router: Router,
    public snackBar: MatSnackBar,
    public dialog: MatDialog,
    public spinner: NgxSpinnerService
  ) { }

  ngOnInit() {
    this.getUsersForm();
  }

  getUsersForm() {
    this.hrService.getUsersForm().toPromise().then(
      data => {
        this.users = data;
        this.sortedData = data;
      });
  }

  seeForm(id) {
    this.hrService.seeForm(id).subscribe(
      next => {
      },
      err => {
        console.log(err);
      }
    );
  }

  fullInfo(user: PersonalInfo) {
    localStorage.setItem('PersonalInfoId', user.Id);
    this.seeForm(user.Id);
    this.router.navigate(['/hr-userformfull']);

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
    this.info = new PersonalInfo('', '', '', '', '', '', '', '', '', '', null, null, '', '');
  }
  sortData(sort: Sort) {
    const data = this.users.slice();
    if (!sort.active || sort.direction === '') {
      this.sortedData = data;
      return;
    }

    this.sortedData = data.sort((a, b) => {
      const isAsc = sort.direction === 'asc';
      switch (sort.active) {
        case 'Surname':
          return compare(a.Surname, b.Surname, isAsc);
        case 'Date':
          return compare(a.Date, b.Date, isAsc);
        case 'Phone':
          return compare(a.Phone, b.Phone, isAsc);
        case 'Position':
          return compare(a.Position, b.Position, isAsc);
        case 'Status':
          return compare(a.Status, b.Status, isAsc);
        default:
          return 0;
      }
    });
  }

}
function compare(a: number | string, b: number | string, isAsc: boolean) {
  return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}
