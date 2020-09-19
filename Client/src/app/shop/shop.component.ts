import { Component, OnInit } from '@angular/core';
import { Pageination } from '../shared/Models/pageination';
import { Product } from '../shared/Models/product';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss'],
})
export class ShopComponent implements OnInit {
  products: Product[];
  pageination: Pageination;

  constructor(private shopService: ShopService) {}

  ngOnInit(): void {
    this.shopService.GetProducts().subscribe((res: Pageination) => {
      this.products = res.data;
    });
  }
}
