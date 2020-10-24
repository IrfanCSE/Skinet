import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CheckOutComponent } from './check-out.component';
import { CheckOutRoutingModule } from './check-out-routing.module';



@NgModule({
  declarations: [CheckOutComponent],
  imports: [
    CommonModule,
    CheckOutRoutingModule
  ]
})
export class CheckOutModule { }
