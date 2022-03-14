import { Component, OnInit } from '@angular/core';
import { UploadEvent, UploadFile, FileSystemFileEntry, FileSystemDirectoryEntry } from 'ngx-file-drop';
import { MatSnackBar, MatDialog } from '@angular/material';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { PersonalInfo } from '../user-form/models/personalInfo.model';
import { HrService } from '../shared/hr.service';
import { EducationInfo } from '../user-form/models/educationInfo.model';
import { Language } from '../user-form/models/language.model';
import { Experience } from '../user-form/models/experience.model';
import { UserProgLang } from '../user-form/models/userProgLang.model';
import { HttpResponse } from '@angular/common/http';
import { UserFormService } from '../user-form/service/user-form.service';
import * as fileSaver from 'file-saver';
import { TextInfo } from '../user-form/models/text.model';
import { Question } from '../user-form/models/question.model';

@Component({
  selector: 'app-hr-userformfull',
  templateUrl: './hr-userformfull.component.html',
  styleUrls: ['./hr-userformfull.component.css']
})
export class HrUserFormFullComponent implements OnInit {
  public files: UploadFile[] = [];
  public personalInfo: PersonalInfo;
  public educationInfo: EducationInfo;
  public languageInfo: Language;
  public experienceInfo: Experience;
  public userProgLangInfo: UserProgLang[];
  public question: Question[];

  textInfo: TextInfo[] = [];
  info: PersonalInfo = new PersonalInfo(null, '', '', '', '', '', '', '', '', '', null, null, '', '');

  public id = localStorage.getItem('PersonalInfoId');
  public idUser = localStorage.getItem('infoId');
  public idPersonalInfo = localStorage.getItem('idPersonalInfo');
  public status = localStorage.getItem('statusForm');

  constructor(
    private hrService: HrService,
    private userFormService: UserFormService,
    private router: Router,
    public snackBar: MatSnackBar,
    public dialog: MatDialog,
    public spinner: NgxSpinnerService
  ) { }

  ngOnInit() {
    this.getPersonalInfo(); 
    this.getEducationInfo();
    this.getLanguage();
    this.getExperience();
    this.getUserProgLang();
    this.getNamesOfTexts();
    this.getQuestion();
  }
  getNamesOfTexts() {
    this.userFormService.getNamesOfTexts(this.id).subscribe(textsInfo => {
      this.textInfo = textsInfo;
    });

  }
  getQuestion() {
    this.hrService.getQuestion(this.id).toPromise().then(
      data => {
        this.question = data;
      });
  }
  getPersonalInfo() {
    this.hrService.getPersonalInfo(this.id).toPromise().then(
      data => {
        this.personalInfo = data;
      });
  }

  getEducationInfo() {
    this.hrService.getEducationInfo(this.id).toPromise().then(
      data => {
        this.educationInfo = data;
      });
  }

  getLanguage() {
    this.hrService.getLanguageInfo(this.id).toPromise().then(
      data => {
        this.languageInfo = data;
      });
  }

  getExperience() {
    this.hrService.getExperienceInfo(this.id).toPromise().then(
      data => {
        this.experienceInfo = data;
      });
  }

  getUserProgLang() {
    this.hrService.getUserProgLangInfo(this.id).toPromise().then(
      data => {
        this.userProgLangInfo = data;
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
    this.info = new PersonalInfo('', '', '', '', '', '', '', '', '', '', null, null, '', '');
  }
  downloadTextById(textArchiveID: number) {
    this.userFormService.downloadTextById(textArchiveID)
      .subscribe(response => {
        const filename = decodeURI(this.getFileNameFromHttpResponse(response).replace(/\+/g, '%20'));
        const fileType = this.getFileTypeFromFileName(filename);
        this.saveFile(response.body, filename, fileType);
      }, error => {
      });
  }

  private saveFile(data: any, filename?: string, fileType?: string) {
    const blob = new Blob([data], { type: fileType });
    fileSaver.saveAs(blob, filename);
  }

  private getFileNameFromHttpResponse(response: HttpResponse<Blob>): string {
    const contentDispositionHeader = response.headers.get('Content-Disposition');
    const result = contentDispositionHeader.split(';')[1].trim().split('=')[1].trim();
    return result;
  }

  private getFileTypeFromFileName(fileName: string): string {
    const checkFileType = fileName.split('.').pop();
    let fileType: string;
    switch (checkFileType) {
      case 'txt': {
        fileType = 'text/plain';
        break;
      }
      case 'pdf': {
        fileType = 'application/pdf';
        break;
      }
      case 'doc':
      case 'docx': {
        fileType = 'application/vnd.ms-word';
        break;
      }
      case 'xls': {
        fileType = 'application/vnd.ms-excel';
        break;
      }
      case 'png': {
        fileType = 'image/png';
        break;
      }
      case 'jpeg':
      case 'jpg': {
        fileType = 'image/jpeg';
        break;
      }
      case 'gif': {
        fileType = 'image/gif';
        break;
      }
      case 'csv': {
        fileType = 'text/csv';
        break;
      }
      default: {
        break;
      }
    }

    return fileType;
  }


}
