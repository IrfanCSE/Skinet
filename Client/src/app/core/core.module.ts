import { RouterModule } from '@angular/router';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotFoundComponent } from './not-found/not-found.component';
import { ServerErrorComponent } from './server-error/server-error.component';
import { ToastrModule } from 'ngx-toastr';
import { SectionHeaderComponent } from './section-header/section-header.component';
import { BreadcrumbModule } from 'xng-breadcrumb';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

@NgModule({
  declarations: [NavBarComponent, NotFoundComponent, ServerErrorComponent, SectionHeaderComponent],
  imports: [CommonModule,
            RouterModule,
            BreadcrumbModule,
            BrowserAnimationsModule,
            BsDropdownModule.forRoot(),
            ToastrModule.forRoot({
              positionClass: 'toast-bottom-right',
              preventDuplicates: true,
            })
          ],
  exports: [
            NavBarComponent,
            NotFoundComponent,
            SectionHeaderComponent
          ],
})
export class CoreModule {}
