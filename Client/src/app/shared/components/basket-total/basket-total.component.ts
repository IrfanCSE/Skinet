import { Observable } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasketTotall } from '../../Models/basket';

@Component({
  selector: 'app-basket-total',
  templateUrl: './basket-total.component.html',
  styleUrls: ['./basket-total.component.scss']
})
export class BasketTotalComponent implements OnInit {

  basketTotal$: Observable<IBasketTotall>;
  constructor(private basketService: BasketService) { }

  ngOnInit(): void {
    this.basketTotal$ = this.basketService.basketTotall$;
  }

}
