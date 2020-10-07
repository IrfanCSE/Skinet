import { RouterModule } from '@angular/router';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotFoundComponent } from './not-found/not-found.component';
import { ServerErrorComponent } from './server-error/server-error.component';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [NavBarComponent, NotFoundComponent, ServerErrorComponent],
  imports: [CommonModule,
            RouterModule,
            ToastrModule.forRoot({
              positionClass: 'toast-bottom-right',
              preventDuplicates: true,
            })
          ],
  exports: [NavBarComponent, NotFoundComponent],
})
export class CoreModule {}
