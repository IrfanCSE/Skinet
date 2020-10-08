import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ShopComponent } from './shop.component';
import { ProductViewComponent } from './product-view/product-view.component';

const routes: Routes = [
  {path: '', component: ShopComponent},
  {path: ':id', component: ProductViewComponent, data: {breadcrumb: {alias: 'productName'}}}
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class ShopRoutingModule { }
