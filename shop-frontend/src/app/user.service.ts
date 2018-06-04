import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { User } from './/user';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { CookieService } from 'ngx-cookie-service';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Access-Control-Allow-Origin': '*'
  }),
  withCredentials: true
};
const httpGetOptions = {
  withCredentials: true
};
@Injectable({
  providedIn: 'root'
})
export class UserService {
  private usersUrl = 'http://localhost:59134/user';  // URL to web api
  private addUserUrl = this.usersUrl + '/add';  // URL to web api
  public currentUser: User;
  public userRole: number;
  public loggedIn: boolean;
  constructor(private http: HttpClient
  ) { this.getUserRole(); }

  getUsers(): Observable<User[]> {
    // this.http.get<User[]>(this.usersUrl + "/get").pipe(
    //   catchError(this.handleError('getUsers', []))
    // );
    return this.http.get<User[]>("http://localhost:59134/user/all", httpGetOptions);
    ;
  }

  postUser(user: User) {
    return this.http.post<User>('http://localhost:59134/user/add', user, httpOptions);
  }

  updateUser(user: User) {
    return this.http.put<User>('http://localhost:59134/user/edit', user, httpOptions);
  }

  getCurrentUser(): Observable<User> {
    return this.http.get<User>('http://localhost:59134/user/currentUser', httpGetOptions);
  }

  getUser(id: number): Observable<User> {
    // TODO: send the message _after_ fetching the hero
    // this.messageService.add(`HeroService: fetched hero id=${id}`);
    console.log("get user method"); // log to console instead    
    return this.http.get<User>("http://localhost:59134/user/" + id, httpGetOptions)
  }

  banUser(id: number) {
    console.log('banned:' + id)
    return this.http.put<any>("http://localhost:59134/user/ban?id=" + id, null, httpOptions);
  }

  unbanUser(id: number) {
    return this.http.put<User>("http://localhost:59134/user/unban?id=" + id, null, httpOptions);
  }
  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      // this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
  getUserRole() {
    if (document.cookie.indexOf('session-id') >= 0)
      this.http.get<User>('http://localhost:59134/user/currentUser', httpOptions).subscribe(user => {
        this.currentUser = user;
        if (this.currentUser == null) {
          this.userRole = null;
          this.loggedIn = false;
          console.log('user is logged out');
        }
        else {
          this.userRole = this.currentUser.UserRole;
          this.loggedIn = true;
          console.log('user is logged in');
        }
      });
    else {
      this.userRole = null;
      this.loggedIn = false;
      console.log('user is logged out');
    }
  }
  setUserLogin(option) {
    this.loggedIn = option;
  }
}
