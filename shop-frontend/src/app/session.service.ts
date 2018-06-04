import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpParams } from '@angular/common/http';
import { User } from './/user';
import { UserService } from './user.service';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  observe: "response" as "body",
  withCredentials: true
};

@Injectable({
  providedIn: 'root'
})
export class SessionService {
  user: User;

  constructor(
    private userService: UserService,
    private http: HttpClient

  ) { }

  logIn(user: User) {
    return this.http.post<HttpResponse<void>>('http://localhost:59134/session/login', user, httpOptions);
  }

  logOut() {
    return this.http.post<HttpResponse<void>>('http://localhost:59134/session/logout', null, httpOptions);
  }


}
