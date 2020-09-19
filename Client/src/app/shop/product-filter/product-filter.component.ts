import { ShopComponent } from './../shop.component';
import { Type } from './../../shared/Models/productType';
import { Brand } from './../../shared/Models/brand';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ProductParams } from 'src/app/shared/Models/productParams';

@Component({
  selector: 'app-product-filter',
  templateUrl: './product-filter.component.html',
  styleUrls: ['./product-filter.component.scss'],
})
export class ProductFilterComponent implements OnInit {

  @Output() brandChanged = new EventEmitter<number>();
  @Output() typeChanged = new EventEmitter<number>();
  @Output() sortChanged = new EventEmitter<string>();

  @Input() brands: Brand[];
  @Input() types: Type[];

  sortOptions = [
    { name: 'Alphabeticl', value: 'name' },
    { name: 'Price: Low to High', value: 'priceAsc' },
    { name: 'Price: High to Low', value: 'priceDesc' },
  ];
  constructor(private shop: ShopComponent) {}

  ngOnInit(): void {}

  OnBrandSelected(brandId: number) {
    this.brandChanged.emit(brandId);
  }
  OnTypeSelected(typeId: number) {
    this.typeChanged.emit(typeId);
  }
  OnSortSelected(sort: string) {
    this.sortChanged.emit(sort);
  }
}
