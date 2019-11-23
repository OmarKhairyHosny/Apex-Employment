import { Component, OnInit } from '@angular/core';
import { ServiceService } from 'src/app/Services/service.service';
import { PRIMARY_OUTLET, Router, UrlTree } from '@angular/router';
import { NgForm } from '@angular/forms';



@Component({
  selector: 'app-empolyee',
  templateUrl: './empolyee.component.html',
  styleUrls: ['./empolyee.component.css']
})
export class EmpolyeeComponent implements OnInit {
  urlTree: UrlTree;
  id : any;
Employees:any;
AllEmployees:any;
Departments: any;
SelectedEmp : any ;
SelectedDepartment:any;
SelectedManager:any;
NewEmployee : any;
  constructor( private _service : ServiceService, private _router: Router) { }

  ngOnInit() {

this.urlTree = this._router.parseUrl(this._router.url);
    this.id = this.urlTree.root.children[PRIMARY_OUTLET].segments[2].path;
    this._service.GetAllDepartments().subscribe(res =>this.Departments=res.json()); 
    this._service.GetAllEmployees().subscribe(res=>this.Employees=this.AllEmployees=res.json());

    if ( this.id != "All"){
      this._service.GetEmployeeByDepId(this.id).subscribe(res=>this.Employees=res.json());
    } 
  }
  
  ChangeDep(val){
    let names= val.split("|");
   this.SelectedDepartment = this.Departments.find((dep) =>{
     return dep.departmentName_En ==  names[0].trim() })
  }

  ChangeEmp(val){
    let names= val.split("|");
    this.SelectedManager = this.AllEmployees.find((emp) =>{
      return emp.name_En ==  names[0].trim()})
  }
  EditDep(val){
    let names= val.split("|");
   this.SelectedEmp.department = this.Departments.find((dep) =>{
     return dep.departmentName_En ==  names[0].trim() })
  }
  EditManager(val){
    let names= val.split("|");
    this.SelectedEmp.manager= this.AllEmployees.find((emp) =>{
      return emp.name_En ==  names[0].trim()})
  }
selectedEmpolye(Emp){
  this.SelectedEmp = Emp; 
}

DeleteEmployee(Emp){
  const index = this.Employees.indexOf(Emp, 0);
  if (index > -1) {
     this.Employees.splice(index, 1);
  }this._service.DeleteEmployee(Emp.id).subscribe();
}

SubmitNewEmp(form:NgForm){
  this.NewEmployee = {
    "name_En" : form.value.name_en,
    "name_ar" : form.value.name_ar,
   // "department":this.SelectedDepartment?this.SelectedDepartment:this.Departments.find((dep) =>{return dep.id == this.id }),
    "departmentId" : this.SelectedDepartment?this.SelectedDepartment.id:this.id,
   // "manager" : this.SelectedManager?this.SelectedManager:null,
    "managerId" : this.SelectedManager?this.SelectedManager.id:null,
    "joinDate" : form.value.Jdate
  }
  console.log(this.NewEmployee);
 this._service.AddEmployee(this.NewEmployee).subscribe(res=>{this.Employees.push(res.json());
  console.log(res);
this.AllEmployees.push(res.json())
});
location.reload();
}
UpdateEmployee(){
  this._service.UpdateEmployee(this.SelectedEmp).subscribe();
}
}
