import { Component, OnInit } from '@angular/core';
import { UploadEvent, UploadFile, FileSystemFileEntry, FileSystemDirectoryEntry } from 'ngx-file-drop';
import { MatSnackBar, MatDialog } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { PersonalInfo } from './models/personalInfo.model';
import { UserFormService } from './service/user-form.service';
import { Language } from './models/language.model';
import { EducationInfo } from './models/educationInfo.model';
import { Experience } from './models/experience.model';
import { ProgLang } from './models/proglang.model';
import { AdminService } from '../shared/admin.service';
import { UserProgLang } from './models/userProgLang.model';
import { TextInfo } from './models/text.model';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css']
})
export class UserFormComponent implements OnInit {
  public files: UploadFile[] = [];

  public progLang: ProgLang[] = [];
  textInfo: TextInfo[] = [];

  isLoginError = false;
  info: PersonalInfo = new PersonalInfo(null, '', '', '', '', '', '', '', '', '', null, null, '', '');
  educationInfo: EducationInfo = new EducationInfo(null, '', '', '', '', '', '', '', '');
  language: Language = new Language(null, '', '', '', '', '', '', '');
  userProgLang: UserProgLang = new UserProgLang(null, '', null, '', '', '');
  experience: Experience = new Experience(null, '', '');
  successMessage = 'Success';
  errorMessage = 'Error';
  successStyle = 'success-snackbar';
  errorStyle = 'error-snackbar';

  constructor(
    private userFormService: UserFormService,
    private adminService: AdminService,
    private router: Router,
    public snackBar: MatSnackBar,
    public dialog: MatDialog,
    public spinner: NgxSpinnerService
  ) { }

  ngOnInit() {
    this.getProgLangs();
  }

  OnSubmit() {
    this.spinner.show();
    this.info.UserId = localStorage.getItem('userId');

    this.userFormService.AddPersonalInfo(this.info).subscribe(next => {

      this.educationInfo.PersonalInfoId = localStorage.getItem('PersonalInfoId');
      this.language.PersonalInfoId = localStorage.getItem('PersonalInfoId');
      this.experience.PersonalInfoId = localStorage.getItem('PersonalInfoId');

      if (next.error === false) {
        this.userFormService.AddEducation(this.educationInfo).subscribe(next => {
          if (next.error === false) {
            this.userFormService.AddLanguage(this.language).subscribe(next => {
              if (next.error === false) {
                this.spinner.hide();
                this.userFormService.AddExperience(this.experience);
                this.userFormService.saveTexts(localStorage.getItem('PersonalInfoId'), this.files)
                this.showSnackBar(this.successMessage, this.successStyle);
                this.setObjectsToDefault();
              } else {
                this.showSnackBar(this.errorMessage, this.errorStyle);
              }
            });
          }
        });
      }

    }, error => {
      console.log(error);
      this.spinner.hide();
    });
  }

  AddProg() {
    this.spinner.show();
    this.userProgLang.PersonalInfoId = localStorage.getItem('PersonalInfoId');
    this.userFormService.AddProgLang(this.userProgLang).subscribe(next => {
      this.spinner.hide();
      if (next.error === false) {
        this.showSnackBar(this.successMessage, this.successStyle);
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
        this.progLang = data;
      });
  }

  public dropped(event: UploadEvent) {
    this.files = [...this.files, ...event.files];
    for (const droppedFile of event.files) {
      if (droppedFile.fileEntry.isFile) {
        const fileEntry = droppedFile.fileEntry as FileSystemFileEntry;
        fileEntry.file((file: File) => {
          console.log(file.name);
        });
      } else {
        const fileEntry = droppedFile.fileEntry as FileSystemDirectoryEntry;
      }
    }
  }

  public deleteFileItem(file: UploadFile) {
    const index = this.files.indexOf(file, 0);
    if (index > -1) {
      this.files.splice(index, 1);
    }
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
    this.educationInfo = new EducationInfo('', '', '', '', '', '', '', '', '');

    this.language = new Language(null, '', '', '', '', '', '', '');
    this.experience = new Experience(null, '', '');
    this.files = [];
  }

}
