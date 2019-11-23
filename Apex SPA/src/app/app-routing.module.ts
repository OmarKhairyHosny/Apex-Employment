import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CompanyModule } from './company/company.module';
import { EmpolyeeComponent } from './company/empolyee/empolyee.component';

const routes: Routes = [
  {
    
    path:'',
    // component : EmpolyeeComponent
    loadChildren : () => CompanyModule
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
