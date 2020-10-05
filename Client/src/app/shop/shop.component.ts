import { Pageination } from './../shared/Models/pageination';
import { Type } from './../shared/Models/productType';
import { Brand } from './../shared/Models/brand';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
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
  pageination: Pageination = {
    count: null,
    data: null,
    pageIndex: null,
    pageSize: null
  };
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
      this.pageination = res;
    },
    error => {
      console.log();
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
    this.productParams.pageIndex = 1;

    this.getProducts();
  }
  OnTypeSelected(typeId: number){
    this.productParams.typeId = typeId;
    this.productParams.pageIndex = 1;
    this.getProducts();

  }
  OnSortSelected(sort: string){
    this.productParams.sort = sort;
    // this.productParams.pageIndex = 1;
    this.getProducts();
  }

  OnSearch(){
    if(this.searchTerm.nativeElement.value){
      this.productParams = new ProductParams();
      this.productParams.search = this.searchTerm.nativeElement.value;
      this.productParams.sort = 'name';
      this.productParams.pageIndex = 1;
      this.getProducts();
    }
  }

  OnReset(){
    this.productParams = new ProductParams();
    this.searchTerm.nativeElement.value = null;

    this.productParams.brandId = 0;
    this.productParams.typeId = 0;
    this.productParams.sort = 'name';
    // this.productParams.pageIndex = 1;

    this.getProducts();
  }

  OnPageChanged($event){
    if ($event.page !== this.productParams.pageIndex){
      this.productParams.pageIndex = $event.page;
      // this.productParams.pageSize = $event.itemsPerPage;
      this.getProducts();
    }
  }

}
