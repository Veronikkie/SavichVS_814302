import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams, HttpResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, Subject, of } from 'rxjs';
import { UploadFile, FileSystemFileEntry } from 'ngx-file-drop';
import { PersonalInfo } from '../models/personalInfo.model';
import { Language } from '../models/language.model';
import { map } from 'rxjs/operators';
import { EducationInfo } from '../models/educationInfo.model';
import { Experience } from '../models/experience.model';
import { UserProgLang } from '../models/userProgLang.model';
import { TextInfo } from '../models/text.model';
import { SaveResult } from '../../shared/save-result.model';
import { Question } from '../models/question.model';
@Injectable({
  providedIn: 'root'
})
export class UserFormService {
  [x: string]: any;
  private URL_WORK = `${environment.apiHostUrl}/api/userform`;
  filesToSave: string[] = [];

  constructor(
    private http: HttpClient
  ) { }

  saveTexts(id: string, files: UploadFile[]): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    let countRequetsts = 0;
    let countResponses = 0;
    const urlFile = this.URL_WORK + '/uploadFiles';

    for (const entryFile of files) {
      const file = entryFile.fileEntry as FileSystemFileEntry;
      this.filesToSave.push(file.name);

      file.file((_file: File) => {
        const formData = new FormData();
        formData.append('UserId', id);
        formData.append('textsCount', files.length.toString());
        formData.append('textIndex', countRequetsts.toString());
        formData.append(_file.name, _file, _file.name);
        countRequetsts++;

        this.http.post(urlFile, formData).subscribe(
          res => {
            const index = this.filesToSave.indexOf(_file.name, 0);
            if (index > -1) {
              this.filesToSave.splice(index, 1);
            }
            countResponses++;
            if (countRequetsts === countResponses) {
              result.next(new SaveResult(true));
            }
          },
          err => {
            countResponses++;
            if (countRequetsts === countResponses) {
              result.next(new SaveResult(false));
            }
          });
      });
    }
    return result.asObservable();
  }
  getNamesOfTexts(UserId: string): Observable<TextInfo[]> {
    return this.http.get<TextInfo[]>(this.URL_WORK + '/getnamesoftext', this.getOptions(UserId));
  }

  downloadTextById(id: number): Observable<HttpResponse<Blob>> {
    const url = `${environment.apiHostUrl}/api/userform/gettextbyid?Id=${id}`;
    let headers = new HttpHeaders();
    headers = headers.append('Accept', '*/*');

    return this.http.get(url, {
      headers: headers,
      observe: 'response',
      responseType: 'blob'
    });
  }
  AddPersonalInfo(info: PersonalInfo): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const urlDoc = this.URL_WORK + '/addinfo';

    this.http.post(urlDoc, info).subscribe(
      res => {
        localStorage.setItem('PersonalInfoId', res.toString());
        result.next(new SaveResult(false));
      },
      err => {
        console.log(err);
        result.next(new SaveResult(true));
      });
    return result.asObservable();
  }

  AddEducation(education: EducationInfo): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const urlDoc = this.URL_WORK + '/addeducation';

    this.http.post(urlDoc, education).subscribe(
      res => {
        result.next(new SaveResult(false));
      },
      err => {
        console.log(err);
        result.next(new SaveResult(true));
      });
    return result.asObservable();
  }

  AddLanguage(language: Language): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const urlDoc = this.URL_WORK + '/addlanguage';

    this.http.post(urlDoc, language).subscribe(
      res => {
        result.next(new SaveResult(false));
      },
      err => {
        console.log(err);
        result.next(new SaveResult(true));
      });
    return result.asObservable();
  }

  AddExperience(experience: Experience): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const urlDoc = this.URL_WORK + '/addexperience';

    this.http.post(urlDoc, experience).subscribe(
      res => {
        result.next(new SaveResult(false));
      },
      err => {
        console.log(err);
        result.next(new SaveResult(true));
      });
    return result.asObservable();
  }


  AddProgLang(proglang: UserProgLang): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const urlDoc = this.URL_WORK + '/adduserproglang';

    this.http.post(urlDoc, proglang).subscribe(
      res => {
        result.next(new SaveResult(false));
      },
      err => {
        console.log(err);
        result.next(new SaveResult(true));
      });
    return result.asObservable();
  }

  getUserStatus(id: string): Observable<PersonalInfo[]> {

    const url = `${environment.apiHostUrl}/api/userform/getuserstatus?id=${id}`;
    return this.http
      .get<PersonalInfo[]>(url)
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new PersonalInfo(item.Id, item.UserId, item.Name, item.Surname, item.Patronymic,
            item.Date, item.Adress, item.Phone, item.Email,
            item.Position, item.MinSalary, item.MaxSalary, item.CreateDate, item.Status));
        })
      );
  }
  AddAnswer(question: Question): Observable<number> {
    console.log(question);
    const result: Subject<number> = new Subject<number>();
    this.http.put(this.URL_WORK + '/addanswer', question).subscribe(
      res => {
        result.next();
      },
      err => {
        result.next();
      }
    );
    return result.asObservable();
  }
  private getOptions(query: string) {
    return {
      params: new HttpParams()
        .set('UserId', query)
    };
  }
}
