import { Component, OnInit } from '@angular/core';
import { MatSnackBar, MatDialog, Sort } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { PersonalInfo } from '../user-form/models/personalInfo.model';
import { HrService } from '../shared/hr.service';

@Component({
  selector: 'app-hr-userform-approve',
  templateUrl: './hr-userform-approve.component.html',
  styleUrls: ['./hr-userform-approve.component.css']
})
export class HrUserFormApproveComponent implements OnInit {

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
    this.getUsersFormApprove();
  }

  getUsersFormApprove() {
    this.hrService.getUsersFormApprove().toPromise().then(
      data => {
        this.users = data;
        this.sortedData = data;
      });
  }

  fullInfo(user: PersonalInfo) {
    localStorage.setItem('PersonalInfoId', user.Id);
    localStorage.setItem('infoId', user.UserId);
    localStorage.setItem('statusForm', user.Status);
    this.router.navigate(['/hr-userformfull']);
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
