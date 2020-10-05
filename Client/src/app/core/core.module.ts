import { RouterModule } from '@angular/router';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotFoundComponent } from './not-found/not-found.component';
import { ServerErrorComponent } from './server-error/server-error.component';

@NgModule({
  declarations: [NavBarComponent, NotFoundComponent, ServerErrorComponent],
  imports: [CommonModule, RouterModule],
  exports: [
    NavBarComponent,
    NotFoundComponent
  ]
})
export class CoreModule {}
