import { Pageination } from './shared/Models/pageination';
import { ShopService } from './shop/shop.service';
import { Component, OnInit } from '@angular/core';
import { Product } from './shared/Models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{

  title = 'Skinet';

  constructor(){
  }
  ngOnInit() {
  }
}
