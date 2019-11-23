import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule,FormsModule } from '@angular/forms';

import { CompanyRoutingModule } from './company-routing.module';
import { CompanyComponent } from './company.component';
import { EmpolyeeComponent } from './empolyee/empolyee.component';
import { DepartmentComponent } from './department/department.component';
 import {TaskesComponent} from './taskes/taskes.component';
import { HomeComponent } from './home/home.component'

@NgModule({
  declarations: [CompanyComponent, TaskesComponent, EmpolyeeComponent, DepartmentComponent, HomeComponent],
  imports: [
    CommonModule,
    CompanyRoutingModule,
    ReactiveFormsModule,
    FormsModule,
  ]
})
export class CompanyModule { }
