import { environment } from './../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.scss']
})
export class TestErrorComponent implements OnInit {

  baseUrl = environment.baseApiUrl;

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  GetNotFound(){
    this.http.get(`${this.baseUrl}buggy/notfound`).subscribe(res => {
      console.log(res);
    }, error => {
      console.log(error);
    });
  }

  GetServerError(){
    this.http.get(`${this.baseUrl}buggy/servererror`).subscribe(res => {
      console.log(res);
    }, error => {
      console.log(error);
    });
  }

  GetBadrequest(){
    this.http.get(`${this.baseUrl}buggy/badrequest`).subscribe(res => {
      console.log(res);
    }, error => {
      console.log(error);
    });
  }

  GetValidationBadrequest(){
    this.http.get(`${this.baseUrl}buggy/badrequest/five`).subscribe(res => {
      console.log(res);
    }, error => {
      console.log(error);
    });
  }

}
