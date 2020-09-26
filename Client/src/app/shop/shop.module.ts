import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {PaginationModule} from 'ngx-bootstrap/pagination';

import { ShopComponent } from './shop.component';
import { ShopService } from './shop.service';
import { ProductsListComponent } from './products-list/products-list.component';
import { ProductFilterComponent } from './product-filter/product-filter.component';
import { ProductViewComponent } from './product-view/product-view.component';
import { ShopRoutingModule } from './shop-routing.module';



@NgModule({
  declarations: [ShopComponent, ProductsListComponent, ProductFilterComponent, ProductViewComponent],
  imports: [
    CommonModule,
    PaginationModule,
    ShopRoutingModule
  ],
  providers: [ShopService],
})
export class ShopModule { }
