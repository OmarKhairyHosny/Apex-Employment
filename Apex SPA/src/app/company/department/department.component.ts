import { Component, OnInit } from '@angular/core';
import { ServiceService } from 'src/app/Services/service.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent implements OnInit {
  Departments: any;
  SelectedDep:any;
  NewDepartment:any={
    "departmentName_Ar":"",
    "departmentName_En":""
  }
  constructor(private _service : ServiceService) { }

  ngOnInit() {
    this._service.GetAllDepartments().subscribe(res =>this.Departments=res.json()); 
  }
  ChangeSelected(Dep){
  this.SelectedDep = Dep;
}
UpdateDepartment(){
  this._service.UpdateDepartMent(this.SelectedDep).subscribe();
}
DeletedDepartment(dep){
  const index = this.Departments.indexOf(dep, 0);
  if (index > -1) {
     this.Departments.splice(index, 1);
  }this._service.DeleteDepartment(dep.id).subscribe();
}
AddNewDepartment()
{
 this._service.AddDepartMent(this.NewDepartment).subscribe(res=>this.Departments.push(res.json()));  
}
}
