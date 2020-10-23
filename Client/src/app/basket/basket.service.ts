import { Product } from './../shared/Models/product';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { Basket, IBasket, IBasketItem } from './../shared/Models/basket';
import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BasketService {
  baseUrl = environment.baseApiUrl;
  private basketSource = new BehaviorSubject<IBasket>(null);
  basket$ = this.basketSource.asObservable();

  constructor(private http: HttpClient) {}

  getBasket(id: string) {
    return this.http.get<IBasket>(this.baseUrl + 'basket?id=' + id).pipe(
      map((response: IBasket) => {
        this.basketSource.next(response);
      })
    );
  }

  setBasket(basket: IBasket) {
    return this.http
      .post<IBasket>(this.baseUrl + 'basket', basket)
      .subscribe((response: IBasket) => {
        this.basketSource.next(response);
        console.log(response);
      });
  }

  setItemInBasket(item: Product, quantity = 1) {
    const basketItemToAdd: IBasketItem = this.mapBasketItemToProductItem(
      item,
      quantity
    );
    const basket = this.getCurrentBasket() ?? this.createNewBasket();
    console.log(basket);
    basket.items = this.addBasketOrUpdate(
      basketItemToAdd,
      basket.items,
      quantity
    );
    console.log(this.getCurrentBasket());
    this.setBasket(basket);
  }

  increaseQuantity(item: IBasketItem) {
    const basket = this.getCurrentBasket();
    const index = basket.items.findIndex((x) => x.id === item.id);
    basket.items[index].quantity++;
    this.setBasket(basket);
  }

  decreaseQuantity(item: IBasketItem) {
    const basket = this.getCurrentBasket();
    const index = basket.items.findIndex((x) => x.id === item.id);
    const currentItem = basket.items[index];
    if (currentItem.quantity > 1) {
      currentItem.quantity--;
      this.setBasket(basket);
    } else {
      this.deleteItemFromBasket(item);
    }
  }

  private addBasketOrUpdate(
    basketItem: IBasketItem,
    items: IBasketItem[],
    quantity: number
  ): IBasketItem[] {
    const index = items.findIndex((x) => x.id === basketItem.id);
    if (index === -1) {
      basketItem.quantity = quantity;
      items.push(basketItem);
    } else {
      items[index].quantity += quantity;
    }
    return items;
  }

  private mapBasketItemToProductItem(item: Product, quantity): IBasketItem {
    return {
      id: item.id,
      productName: item.name,
      price: item.price,
      pictureUrl: item.pictureUrl,
      quantity,
      brand: item.productBrand,
      type: item.productType,
    };
  }

  createNewBasket() {
    const basket = new Basket();
    localStorage.setItem('basket_id', basket.id);
    return basket;
  }

  getCurrentBasket() {
    return this.basketSource.value;
  }

  deleteItemFromBasket(item: IBasketItem) {
    const basket = this.getCurrentBasket();
    if (basket.items.some((x) => x.id === item.id)) {
      basket.items = basket.items.filter((x) => x.id !== item.id);
      if (basket.items.length > 0) {
        this.setBasket(basket);
      } else {
        this.deleteBasket(basket.id);
      }
    }
  }

  deleteBasket(id: string) {
    this.http.delete(this.baseUrl + 'basket?id=' + id).subscribe(() => {
      this.basketSource.next(null);
      localStorage.removeItem('basket_id');
    });
  }
}
