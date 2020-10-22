import { BasketService } from './../../basket/basket.service';
import { Product } from './../../shared/Models/product';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.scss']
})
export class ProductsListComponent implements OnInit {

  @Input() products: Product[];

  constructor(private basketService: BasketService) { }

  ngOnInit(): void {
  }

  addProductToBasket(product: Product){
    this.basketService.setItemInBasket(product);
  }

}
