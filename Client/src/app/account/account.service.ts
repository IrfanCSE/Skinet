import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from './../../environments/environment';
import { User } from './../shared/Models/user';
import { Injectable } from '@angular/core';
import { ReplaySubject, of } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl = environment.baseApiUrl;
  currentUserSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient, private router: Router) { }

  loadCurrentUser(token: string){
    if (token === null){
      this.currentUserSource.next(null);
      return of(null);
    }

    let header = new HttpHeaders();
    header = header.set('Authorization', `Bearer ${token}`);

    return this.http.get(this.baseUrl + 'account', {headers: header}).pipe(
      map((user: User) => {
          localStorage.setItem('token', user.token);
          this.currentUserSource.next(user);
      })
    );
  }

  login(value: any){
    return this.http.post(this.baseUrl + 'account/login', value).pipe(
      map((user: User) => {
        if (user){
        localStorage.setItem('token', user.token);
        this.currentUserSource.next(user);
      }
      })
    );
  }

  register(value: any){
    return this.http.post(this.baseUrl + 'account/register', value).pipe(
      map((user: User) => {
        localStorage.setItem('token', user.token);
        this.currentUserSource.next(user);
        this.router.navigateByUrl('/shop');
      })
    );
  }

  logout(){
    localStorage.removeItem('token');
    this.currentUserSource.next(null);
    this.router.navigateByUrl('/');
  }

  checkEmailExist(email: string){
    return this.http.get(this.baseUrl + 'account/emailExists?email=' + email);
  }
}
