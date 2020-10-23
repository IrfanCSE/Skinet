import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { BasketComponent } from './basket.component';

const routes: Routes = [
  {path: '', component: BasketComponent}
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class BasketRoutingModule { }
