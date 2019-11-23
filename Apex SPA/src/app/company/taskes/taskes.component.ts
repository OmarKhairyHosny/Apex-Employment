import { Component, OnInit } from '@angular/core';
import { ServiceService } from 'src/app/Services/service.service';
import { PRIMARY_OUTLET, Router, UrlTree } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-taskes',
  templateUrl: './taskes.component.html',
  styleUrls: ['./taskes.component.css']
})
export class TaskesComponent implements OnInit {
Tasks:any;
urlTree: UrlTree;
id : any;
Employees:any;
SelectedTask:any;
NewTask:any;
selectedEmpolyee:any;
  constructor(private _service : ServiceService, private _router: Router) { }

  ngOnInit() {
    this.urlTree = this._router.parseUrl(this._router.url);
    this.id = this.urlTree.root.children[PRIMARY_OUTLET].segments[2].path;
    this._service.GetAllEmployees().subscribe(res=>this.Employees=res.json());
    
    if ( this.id != "All"){
      this._service.GetTasksByEmpId(this.id).subscribe(res=>this.Tasks=res.json());
    } 
    else{
      this._service.GetAllTasks().subscribe(res=>this.Tasks=res.json())

    }
  }
  ChangeSelectedTask(tsk){
    this.SelectedTask = tsk; 
  }
  EditTaskEmployee(val){
    let names= val.split("|");
    this.SelectedTask.employee= this.Employees.find((emp) =>{
      return emp.name_En ==  names[0].trim()})
  }
  DeleteTask(tsk){
    const index = this.Tasks.indexOf(tsk, 0);
    if (index > -1) {
       this.Tasks.splice(index, 1);
    }this._service.DeleteTask(tsk.id).subscribe();
  }
  
  SubmitNewTask(form:NgForm){
    this.NewTask = {
      "title" : form.value.title,
      "description" : form.value.desc,
      "startDate" : form.value.sdate,
      "endDate" : form.value.edate,
      "employeeId" : this.selectedEmpolyee?this.selectedEmpolyee.id:this.id
    }
this._service.AddTask(this.NewTask).subscribe(res=>this.Tasks.push(res.json()))
  }
  UpdateTask(){
    console.log(this.SelectedTask)
    this._service.UpdateTask(this.SelectedTask).subscribe();
    location.reload();
  }
  SetAssign(val){
    let names= val.split("|");
    this.selectedEmpolyee = this.Employees.find((emp) =>{
      return emp.name_En ==  names[0].trim()})
  }
}
