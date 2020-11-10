import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private router: Router, private toastr: ToastrService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError(error => {
        if (error){
          if (error.status === 400){
            this.toastr.error(error.statusText, error.status);
          }

          if (error.status === 404){
            this.router.navigateByUrl('/not-found');
          }

          if (error.status === 500){
            this.router.navigateByUrl('/server-error');
          }

          if (error.status === 401){
            this.toastr.error(error.statusText, error.status);
          }
        }
        return throwError(error);
      })
    );
  }
}
