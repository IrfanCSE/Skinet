import { IBasket } from './../../shared/Models/basket';
import { Observable } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { BasketService } from 'src/app/basket/basket.service';
import { AccountService } from 'src/app/account/account.service';
import { User } from 'src/app/shared/Models/user';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {

  basket$: Observable<IBasket>;
  user$: Observable<User>;

  constructor(private basketService: BasketService, private accountService: AccountService) { }

  ngOnInit(){
    this.basket$ = this.basketService.basket$;
    this.user$ = this.accountService.currentUser$;
  }

}
