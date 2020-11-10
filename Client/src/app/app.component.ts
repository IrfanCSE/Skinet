import { AccountService } from './account/account.service';
import { Component, OnInit } from '@angular/core';
import { BasketService } from './basket/basket.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'Skinet';

  constructor(
    private basketService: BasketService,
    private accountService: AccountService
  ) {}
  ngOnInit() {
    this.loadCurrentUser();
    this.loadCurrentBasket();
  }

  loadCurrentBasket() {
    const key = localStorage.getItem('basket_id');
    this.basketService.getBasket(key).subscribe(() => {
      console.log('Basket Inital');
    });
  }

  loadCurrentUser() {
    const token = localStorage.getItem('token');
    this.accountService.loadCurrentUser(token).subscribe(
      () => {
        console.log('Load User');
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
