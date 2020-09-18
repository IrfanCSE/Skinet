import { Pageination } from './Models/pageination';
import { Product } from './Models/product';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{

  title = 'Skinet';
  products: Product[];
  pageination: Pageination;

  constructor(private http: HttpClient){
  }

  ngOnInit(){
    this.http.get('https://localhost:5001/api/products').subscribe((res: Pageination) => {
      this.products = res.data;
    }, error => {
      console.log(error);
    });
  }

}
