import { Component, OnInit } from '@angular/core';
import { MatSnackBar, MatDialog, Sort } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { PersonalInfo } from '../user-form/models/personalInfo.model';
import { HrService } from '../shared/hr.service';

@Component({
  selector: 'app-hr-userform-reject',
  templateUrl: './hr-userform-reject.component.html',
  styleUrls: ['./hr-userform-reject.component.css']
})
export class HrUserFormRejectComponent implements OnInit {

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
    this.getUsersFormReject();
  }

  getUsersFormReject() {
    this.hrService.getUsersFormReject().toPromise().then(
      data => {
        this.users = data;
        this.sortedData = data;
      });
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
