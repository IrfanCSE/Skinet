import { Type } from './../shared/Models/productType';
import { Brand } from './../shared/Models/brand';
import { Component, OnInit } from '@angular/core';
import { Pageination } from '../shared/Models/pageination';
import { Product } from '../shared/Models/product';
import { ShopService } from './shop.service';
import { ProductParams } from '../shared/Models/productParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss'],
})
export class ShopComponent implements OnInit {
  products: Product[];
  brands: Brand[];
  types: Type[];
  pageination: Pageination;
  productParams = new ProductParams();

  constructor(private shopService: ShopService) {}

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  getProducts() {
    this.shopService.getProducts(this.productParams).subscribe(res => {
      this.products = res.data;
    });
  }

  getBrands(){
    this.shopService.getBrands().subscribe(res => {
      this.brands = res;
    });
  }

  getTypes(){
    this.shopService.getTypes().subscribe(res => {
      this.types = res;
    });
  }

  OnBrandSelected(brandId: number){
    this.productParams.brandId = brandId;
    this.getProducts();
    console.log(brandId);
  }
  OnTypeSelected(typeId: number){
    this.productParams.typeId = typeId;
    this.getProducts();
    console.log(typeId);

  }
  OnSortSelected(sort: string){
    this.productParams.sort = sort;
    this.getProducts();
    console.log(sort);
  }

}
