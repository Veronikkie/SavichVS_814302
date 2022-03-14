import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { User, UserReg } from './user.model';
import { Observable, Subject } from 'rxjs';
import { PersonalInfo } from '../user-form/models/personalInfo.model';
import { Language } from '../user-form/models/language.model';
import { EducationInfo } from '../user-form/models/educationInfo.model';
import { Experience } from '../user-form/models/experience.model';
import { UserProgLang } from '../user-form/models/userProgLang.model';
import { Question } from '../user-form/models/question.model';
import { SaveResult } from './save-result.model';

@Injectable({
  providedIn: 'root'
})
export class HrService {
  [x: string]: any;
  private URL_USER = `${environment.apiHostUrl}/api/userform`;

  constructor(
    private http: HttpClient
  ) { }



  getUsersForm(): Observable<PersonalInfo[]> {
    return this.http
      .get<PersonalInfo[]>(this.URL_USER + '/getusersform')
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new PersonalInfo(item.Id, item.UserId, item.Name, item.Surname, item.Patronymic,
            item.Date, item.Adress, item.Phone, item.Email,
            item.Position, item.MinSalary, item.MaxSalary, item.CraeteDate, item.Status));
        })
      );
  }

  getUsersFormSee(): Observable<PersonalInfo[]> {
    return this.http
      .get<PersonalInfo[]>(this.URL_USER + '/getusersformsee')
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new PersonalInfo(item.Id, item.UserId, item.Name, item.Surname, item.Patronymic,
            item.Date, item.Adress, item.Phone, item.Email,
            item.Position, item.MinSalary, item.MaxSalary, item.CreateDate, item.Status));
        })
      );
  }

  getUsersFormApprove(): Observable<PersonalInfo[]> {
    return this.http
      .get<PersonalInfo[]>(this.URL_USER + '/getusersformapprove')
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new PersonalInfo(item.Id, item.UserId, item.Name, item.Surname, item.Patronymic,
            item.Date, item.Adress, item.Phone, item.Email,
            item.Position, item.MinSalary, item.MaxSalary, item.CreateDate, item.Status));
        })
      );
  }

  getUsersFormReject(): Observable<PersonalInfo[]> {
    return this.http
      .get<PersonalInfo[]>(this.URL_USER + '/getusersformreject')
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new PersonalInfo(item.Id, item.UserId, item.Name, item.Surname, item.Patronymic,
            item.Date, item.Adress, item.Phone, item.Email,
            item.Position, item.MinSalary, item.MaxSalary, item.CreateDate, item.Status));
        })
      );
  }

  getPersonalInfo(id: string): Observable<PersonalInfo> {
    const url = `${environment.apiHostUrl}/api/userform/getpersonalinfo`;
    return this.http
      .get<PersonalInfo>(url, this.getOptions(id))
      .pipe(
        map(res => {
          const result: any = res;
          return result;
        })
      );
  }
  getEducationInfo(id: string): Observable<EducationInfo> {
    const url = `${environment.apiHostUrl}/api/userform/geteducation`;
    return this.http
      .get<EducationInfo>(url, this.getOptions(id))
      .pipe(
        map(res => {
          const result: any = res;
          return result;
        })
      );
  }

  getLanguageInfo(id: string): Observable<Language> {
    const url = `${environment.apiHostUrl}/api/userform/getlanguage`;
    return this.http
      .get<Language>(url, this.getOptions(id))
      .pipe(
        map(res => {
          const result: any = res;
          return result;
        })
      );
  }

  getExperienceInfo(id: string): Observable<Experience> {
    const url = `${environment.apiHostUrl}/api/userform/getexperience`;
    return this.http
      .get<Experience>(url, this.getOptions(id))
      .pipe(
        map(res => {
          const result: any = res;
          return result;
        })
      );
  }

  getUserProgLangInfo(id: string): Observable<UserProgLang[]> {
    return this.http
      .get<UserProgLang[]>(this.URL_USER + '/getuserproglang', this.getOptions(id))
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new UserProgLang(item.Id, item.UserId, item.ProgLangId, item.ProgLangs.ProgLang, item.Level,
            item.Period));
        })
      );
  }

  getQuestion(id: string): Observable<Question[]> {

    const url = `${environment.apiHostUrl}/api/userform/getquestion?Id=${id}`;
    return this.http
      .get<Question[]>(url)
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new Question(item.Id, item.PersonalInfoId, item.Question, item.Answer));
        })
      );
  }
  seeForm(id: string): Observable<SaveResult> {
    const url = `${environment.apiHostUrl}/api/userform/seeform?id=${id}`;
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    this.http.get(url).subscribe(
      res => {
        result.next();
      },
      err => {
        result.next();
      }
    );
    return result.asObservable();
  }

  Approve(id: string): Observable<SaveResult> {
    const url = `${environment.apiHostUrl}/api/userform/approve?Userid=${id}`;
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    this.http.get(url).subscribe(
      res => {
        result.next();
      },
      err => {
        result.next();
      }
    );
    return result.asObservable();
  }

  Reject(id: string): Observable<SaveResult> {
    const url = `${environment.apiHostUrl}/api/userform/reject?Userid=${id}`;
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    this.http.get(url).subscribe(
      res => {
        result.next();
      },
      err => {
        result.next();
      }
    );
    return result.asObservable();
  }

  AddQuestion(newQuestion: Question): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const urlDoc = this.URL_USER + '/addquestion';

    this.http.post(urlDoc, newQuestion).subscribe(
      res => {
        result.next(new SaveResult(false));
      },
      err => {
        console.log(err);
        result.next(new SaveResult(true));
      });
    return result.asObservable();
  }

  private getOptions(query: string) {
    return {
      params: new HttpParams()
        .set('UserId', query)
    };
  }
}
