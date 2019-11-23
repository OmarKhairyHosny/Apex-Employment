import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CompanyComponent } from './company.component';
import { EmpolyeeComponent } from './empolyee/empolyee.component';
import { DepartmentComponent } from './department/department.component';
import { TaskesComponent } from './taskes/taskes.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [{
  path :'',
  component : CompanyComponent,
  children : [
    {
      path: '',
      redirectTo: 'Home',
      pathMatch: 'full'
    },{
      path : 'Home',
      component : HomeComponent
    }

    ,{
      path :'Home/Empolyee/:id',
      component : EmpolyeeComponent,
    },{

      path :'Home/Department',
      component : DepartmentComponent,
    },
    {
      path :'Home/Tasks/:id',
      component : TaskesComponent,
    }
  ]
 },




];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CompanyRoutingModule { }
