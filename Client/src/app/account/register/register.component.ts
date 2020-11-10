import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { AccountService } from './../account.service';
import { Component, OnInit } from '@angular/core';
import { AsyncValidatorFn, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { of } from 'rxjs';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;

  constructor(private fb: FormBuilder, private accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
    this.createRegisterForm();
  }

  createRegisterForm(){
    this.registerForm = this.fb.group({
      displayName: [null, [Validators.required]],
      email: [null,
        [Validators.required, Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')],
        [this.emailExistAsync()]
      ],
      password: [null, [Validators.required]]
    });
  }

  onSubmit(){
    this.accountService.register(this.registerForm.value).subscribe(res => {
      this.router.navigateByUrl('/shop');
    }, error => {
      console.log(error);
    });
  }

  emailExistAsync(): AsyncValidatorFn{
    return control => {
      if (!control.value){
        return of(null);
      }
      return this.accountService.checkEmailExist(control.value).pipe(
        map(res => {
          return res ? {emailExist: true} : null;
        })
      );
    };
  }

}
