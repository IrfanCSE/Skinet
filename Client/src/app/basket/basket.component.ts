import { Product } from './../shared/Models/product';
import { Observable } from 'rxjs';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasket, IBasketItem } from './../shared/Models/basket';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent implements OnInit {

  basket$: Observable<IBasket>;
  constructor(private basketService: BasketService) { }

  ngOnInit(): void {
    this.basket$ = this.basketService.basket$;
  }

  IncreasQuantity(item: IBasketItem){
    this.basketService.increaseQuantity(item);
  }

  DecreasQuantity(item: IBasketItem){
    this.basketService.decreaseQuantity(item);
  }

  RemoveItem(item: IBasketItem){
    this.basketService.deleteItemFromBasket(item);
  }
}
