import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UploadEvent, UploadFile, FileSystemFileEntry, FileSystemDirectoryEntry } from 'ngx-file-drop';
import { MatSnackBar, MatDialog } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { DatePipe } from '@angular/common';
import { AdminService } from '../shared/admin.service';
import { UserReg } from '../shared/user.model';
import { PersonalInfo } from '../user-form/models/personalInfo.model';
import { HrService } from '../shared/hr.service';
import { UserFormService } from '../user-form/service/user-form.service';
import { Question } from '../user-form/models/question.model';

@Component({
  selector: 'app-user-status',
  templateUrl: './user-status.component.html',
  styleUrls: ['./user-status.component.css']
})
export class UserStatusComponent implements OnInit {
  public files: UploadFile[] = [];
  public users: PersonalInfo[] = [];

  public questions: Question[] = [];
   public statusId = localStorage.getItem('userId');


  public addQuestion: boolean = false;
  public addAnswer: boolean = false;
  info: PersonalInfo = new PersonalInfo(null, '', '', '', '', '', '', '', '', '', null, null, '', '');
  newQuestion: Question = new Question(null, null, null, '');
  successMessage = 'Новый менеджер добавлен успешно.';
  successDelMessage = 'Пользователь удален успешно.';
  errorMessage = 'Проверьте данные. Ошибка добавления.';
  successStyle = 'success-snackbar';
  errorStyle = 'error-snackbar';

  constructor(
    private userFormService:UserFormService,
    private hrService:HrService,
    private router: Router,
    public snackBar: MatSnackBar,
    public dialog: MatDialog,
    public spinner: NgxSpinnerService
  ) { }

  ngOnInit() {
    this.getUserStatus();
  }

  getUserStatus() {
    this.userFormService.getUserStatus(this.statusId).toPromise().then(
      data => {
        this.users = data;
      });
  }
  question(Id: string) {
  
    localStorage.setItem('personalInfoId', Id);
    this.getQuestion();
    this.addQuestion = true;
  }
  add(question: Question) {

    localStorage.setItem('Id', question.Id.toString());
    localStorage.setItem('PersonalId', question.PersonalInfoId);
    this.newQuestion.Question = question.Question;
    this.newQuestion.Id = question.Id;
    this.newQuestion.PersonalInfoId = question.PersonalInfoId;
    this.addAnswer = true;
  }
  getQuestion() {
    const idPersonalInfo = localStorage.getItem('personalInfoId');
    this.hrService.getQuestion(idPersonalInfo).toPromise().then(
      data => {
        this.questions = data;
      });
  }

  AddAnswer() {
    console.log(this.newQuestion)
    this.userFormService.AddAnswer(this.newQuestion).subscribe(next => {
      this.addQuestion = false;
      this.getUserStatus();
      this.setObjectsToDefault();
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
    this.newQuestion = new Question(null, '', '', '');
  }

}
