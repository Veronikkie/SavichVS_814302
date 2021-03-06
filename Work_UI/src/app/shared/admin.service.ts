import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { User, UserReg } from './user.model';
import { Observable, Subject } from 'rxjs';
import { ProgLang } from '../user-form/models/proglang.model';
import { SaveResult } from './save-result.model';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  [x: string]: any;
  private URL_REG = `${environment.apiHostUrl}/api/userregistration`;

  private URL_USER = `${environment.apiHostUrl}/api/user`;
  private URL_ADMIN = `${environment.apiHostUrl}/api/admin`;

  constructor(
    private http: HttpClient
  ) { }


  HrRegistration(newUser: UserReg): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const urlDoc = this.URL_REG + '/addhr';

    this.http.post(urlDoc, newUser).subscribe(
      res => {
        if (res)
          result.next(new SaveResult(false));
        else
          result.next(new SaveResult(true));
      },
      error => {
        result.next(new SaveResult(true));
      });

    return result.asObservable();
  }

  AddProgLang(newProglang: ProgLang): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const urlDoc = this.URL_ADMIN + '/addproglang';

    this.http.post(urlDoc, newProglang).subscribe(
      res => {
        if (res)
          result.next(new SaveResult(false));
        else
          result.next(new SaveResult(true));
      },
      error => {
        result.next(new SaveResult(true));
      });

    return result.asObservable();
  }


  DeleteUser(Id: string): Observable<SaveResult> {
    const result: Subject<SaveResult> = new Subject<SaveResult>();
    const url = `${environment.apiHostUrl}/api/user/deluser?Id=${Id}`;

    this.http.get(url).subscribe(
      res => {
        if (res)
          result.next(new SaveResult(false));
        else
          result.next(new SaveResult(true));
      },
      error => {
        result.next(new SaveResult(true));
      });

    return result.asObservable();
  }



  getUsers(): Observable<UserReg[]> {
    return this.http
      .get<UserReg[]>(this.URL_USER + '/getusers')
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new UserReg(item.Id, item.Created, item.Email, item.Password, item.UserName, item.RoleId, item.Role.RoleName, item.Name, item.Surname));
        })
      );
  }

  getProgLangs(): Observable<ProgLang[]> {
    return this.http
      .get<ProgLang[]>(this.URL_ADMIN + '/getproglangs')
      .pipe(
        map(res => {
          const result: any = res;
          return result.map(item => new ProgLang(item.Id, item.ProgLang));
        })
      );
  }
  private getOptionsCustom(Id: string) {
    return {
      params: new HttpParams()
        .set('Id', Id)
    };
  }
}
