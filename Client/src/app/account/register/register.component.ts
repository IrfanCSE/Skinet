import { Router } from '@angular/router';
import { AccountService } from './../account.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

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
      email: [null, [Validators.required, Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')]],
      password: [null, [Validators.required]]
    });
  }

  onSubmit(){
    this.accountService.register(this.registerForm.value).subscribe(res => {
      this.router.navigateByUrl('/shop');
    },error =>{
      console.log(error);
    });
  }

}
