import { Component, OnInit } from '@angular/core';
import { BasketService } from './basket/basket.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{

  title = 'Skinet';

  constructor(private basketService: BasketService){
  }
  ngOnInit() {
    const key = localStorage.getItem('basket_id');
    this.basketService.getBasket(key).subscribe(response => {
      console.log('Basket Inital: ' + response);
    });
  }
}
