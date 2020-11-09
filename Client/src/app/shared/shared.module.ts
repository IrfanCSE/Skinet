import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasketTotalComponent } from './components/basket-total/basket-total.component';
import { ReactiveFormsModule } from '@angular/forms';
import { InputFieldComponent } from './components/input-field/input-field.component';

@NgModule({
  declarations: [BasketTotalComponent, InputFieldComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  exports: [
    BasketTotalComponent,
    ReactiveFormsModule,
    InputFieldComponent
  ]
})
export class SharedModule { }
