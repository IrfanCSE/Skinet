import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { environment } from './../../environments/environment';
import { User } from './../shared/Models/user';
import { Injectable } from '@angular/core';
import { BehaviorSubject, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl = environment.baseApiUrl;
  currentUserSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient, private router: Router) { }

  login(value: any){
    return this.http.post(this.baseUrl + 'account/login', value).pipe(
      map((user: User) => {
        if (user){
        localStorage.setItem('token', user.token);
        this.currentUserSource.next(user);
        console.log(user);
        this.router.navigateByUrl('/shop');
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
