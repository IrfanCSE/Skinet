import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {PaginationModule} from 'ngx-bootstrap/pagination';

import { ShopComponent } from './shop.component';
import { ShopService } from './shop.service';
import { ProductsListComponent } from './products-list/products-list.component';
import { ProductFilterComponent } from './product-filter/product-filter.component';



@NgModule({
  declarations: [ShopComponent, ProductsListComponent, ProductFilterComponent],
  imports: [
    CommonModule,
    PaginationModule
  ],
  providers: [ShopService],
  exports: [ShopComponent]
})
export class ShopModule { }
