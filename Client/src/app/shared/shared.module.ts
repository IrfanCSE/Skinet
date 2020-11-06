import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasketTotalComponent } from './components/basket-total/basket-total.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [BasketTotalComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  exports: [
    BasketTotalComponent,
    ReactiveFormsModule
  ]
})
export class SharedModule { }
