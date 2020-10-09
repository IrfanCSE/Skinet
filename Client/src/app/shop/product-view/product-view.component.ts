import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/shared/Models/product';
import { BreadcrumbService } from 'xng-breadcrumb';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-view',
  templateUrl: './product-view.component.html',
  styleUrls: ['./product-view.component.scss']
})
export class ProductViewComponent implements OnInit {

  product: Product;

  constructor(private shopService: ShopService, private param: ActivatedRoute, private bcService: BreadcrumbService) {
    this.bcService.set('@productName', ' ');
  }

  ngOnInit(): void {
    const id = this.getProductId();
    this.getProduct(id);
  }

  getProduct(id: number){
    this.shopService.getProduct(id).subscribe(res => {
      this.product = res;
      this.bcService.set('@productName', this.product.name);
    },
    error => {
      console.log(error);
    });
  }

  getProductId(){
    return +this.param.snapshot.paramMap.get('id');
  }

}
