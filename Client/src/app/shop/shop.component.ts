import { Type } from './../shared/Models/productType';
import { Brand } from './../shared/Models/brand';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
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

  @ViewChild('search') searchTerm: ElementRef;

  constructor(private shopService: ShopService) {}

  ngOnInit(): void {
    this.productParams.brandId = 0;
    this.productParams.typeId = 0;

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
      this.brands = [{id: 0, name: 'All'}, ...res];
    });
  }

  getTypes(){
    this.shopService.getTypes().subscribe(res => {
      this.types = [{id: 0, name: 'All'}, ...res];
    });
  }

  OnBrandSelected(brandId: number){
    this.productParams.brandId = brandId;
    this.getProducts();
  }
  OnTypeSelected(typeId: number){
    this.productParams.typeId = typeId;
    this.getProducts();

  }
  OnSortSelected(sort: string){
    this.productParams.sort = sort;
    this.getProducts();
  }

  OnSearch(){
    this.productParams = new ProductParams();
    this.productParams.search = this.searchTerm.nativeElement.value;
    this.productParams.sort = 'name';

    this.getProducts();
  }

  OnReset(){
    this.productParams = new ProductParams();
    this.searchTerm.nativeElement.value = null;

    this.productParams.brandId = 0;
    this.productParams.typeId = 0;
    this.productParams.sort = 'name';

    this.getProducts();
  }

}
