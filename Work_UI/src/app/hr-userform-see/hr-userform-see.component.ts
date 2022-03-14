import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UploadEvent, UploadFile, FileSystemFileEntry, FileSystemDirectoryEntry } from 'ngx-file-drop';
import { MatSnackBar, MatDialog, Sort } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { DatePipe } from '@angular/common';
import { UserReg } from '../shared/user.model';
import { PersonalInfo } from '../user-form/models/personalInfo.model';
import { HrService } from '../shared/hr.service';
import { Question } from '../user-form/models/question.model';

@Component({
  selector: 'app-hr-userform-see',
  templateUrl: './hr-userform-see.component.html',
  styleUrls: ['./hr-userform-see.component.css']
})
export class HrUserFormSeeComponent implements OnInit {
  public files: UploadFile[] = [];
  public users: PersonalInfo[] = [];
  public sortedData: PersonalInfo[] = [];
  public questions: Question[] = [];
  public addQuestion: boolean = false;

  isLoginError = false;
  info: PersonalInfo = new PersonalInfo(null, '', '', '', '', '', '', '', '', '', null, null, '', '');
  newQuestion: Question = new Question(null, null, null, '');
  successMessage = 'Новый менеджер добавлен успешно.';
  successDelMessage = 'Пользователь удален успешно.';
  errorMessage = 'Проверьте данные. Ошибка добавления.';
  successStyle = 'success-snackbar';
  errorStyle = 'error-snackbar';

  constructor(
    private hrService: HrService,
    private router: Router,
    public snackBar: MatSnackBar,
    public dialog: MatDialog,
    public spinner: NgxSpinnerService
  ) { }

  ngOnInit() {
    this.getUsersFormSee();
  }

  getUsersFormSee() {
    this.hrService.getUsersFormSee().toPromise().then(
      data => {
        this.users = data;
        this.sortedData = data;
      });
  }

  approve(id) {
    this.hrService.Approve(id).subscribe(
      next => {
        this.getUsersFormSee();
      },
      err => {
        console.log(err);
      }
    );
  }
  reject(id) {
    this.hrService.Reject(id).subscribe(
      next => {
        this.getUsersFormSee();
      },
      err => {
        console.log(err);
      }
    );
  }

  fullInfo(user: PersonalInfo) {

    localStorage.setItem('infoId', user.UserId);
    localStorage.setItem('PersonalInfoId', user.Id);
    localStorage.setItem('statusForm', user.Status);
    this.router.navigate(['/hr-userformfull']);

  }
  question(Id: string) {
    this.addQuestion = true;
    console.log(Id)
    localStorage.setItem('personalInfoId', Id);
  }
  AddQuestion() {
    this.newQuestion.PersonalInfoId = localStorage.getItem('personalInfoId');
    console.log(this.newQuestion)
    this.hrService.AddQuestion(this.newQuestion).subscribe(next => {
      this.addQuestion = false;
      this.getUsersFormSee();
    }, error => {
      console.log(error);
      this.spinner.hide();
    });
  } sortData(sort: Sort) {
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
