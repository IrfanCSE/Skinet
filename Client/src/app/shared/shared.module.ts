import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasketTotalComponent } from './components/basket-total/basket-total.component';

@NgModule({
  declarations: [BasketTotalComponent],
  imports: [
    CommonModule,
  ],
  exports: [
    BasketTotalComponent
  ]
})
export class SharedModule { }
