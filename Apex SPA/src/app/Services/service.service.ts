import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from '@angular/http';

const httpOptions = {
  headers: new Headers({
    'Content-Type': 'application/json'
  })
};
@Injectable({
  providedIn: 'root'
})
export class ServiceService {
  apiRoot: string = "https://localhost:44300/api";
  constructor(private http: Http) { }
  /* #region  Employee Methods */
  GetAllEmployees() {
    const url = `${this.apiRoot}/Employees`;
    return this.http.get(url);
  }
  GetEmployee(id) {
    const url = `${this.apiRoot}/Employees/${id}`;
    return this.http.get(url);
  }
  GetEmployeeByDepId(id) {
    const url = `${this.apiRoot}/Employees/GetEmployeesByDepId/${id}`;
    return this.http.get(url);
  }
  AddEmployee(Emp) {
    const url = `${this.apiRoot}/Employees`;
    return this.http.post(url, Emp);
  }
  UpdateEmployee(Emp) {
    const url = `${this.apiRoot}/Employees/${Emp.id}`;
    return this.http.put(url, Emp);
  }
  DeleteEmployee(id) {
    let url = `${this.apiRoot}/Employees/${id}`;
    return this.http.delete(url);
  }
  /* #endregion */

 /* #region  Departments Methods */
 GetAllDepartments() {
  const url = `${this.apiRoot}/Departments`;
  return this.http.get(url);
}
GetDepartment(id) {
  const url = `${this.apiRoot}/Departments/${id}`;
  return this.http.get(url);
}
AddDepartMent(dep) {
  const url = `${this.apiRoot}/Departments`;
  return this.http.post(url, dep);
}
UpdateDepartMent(dep) {
  const url = `${this.apiRoot}/Departments/${dep.id}`;
  console.log(dep);
  return this.http.put(url, dep);
}
DeleteDepartment(id) {
  let url = `${this.apiRoot}/Departments/${id}`;
  return this.http.delete(url);
}
/* #endregion */

 /* #region  Tasks Methods */
 GetAllTasks() {
  const url = `${this.apiRoot}/Tasks`;
  return this.http.get(url);
}
GetTask(id) {
  const url = `${this.apiRoot}/Tasks/${id}`;
  return this.http.get(url);
}
GetTasksByEmpId(id) {
  const url = `${this.apiRoot}/Tasks/GetTasksByEmpId/${id}`;
  return this.http.get(url);
}
AddTask(task) {
  const url = `${this.apiRoot}/Tasks`;
  return this.http.post(url, task);
}
UpdateTask(task) {
  const url = `${this.apiRoot}/Tasks/${task.id}`;
  return this.http.put(url, task);
}
DeleteTask(id) {
  let url = `${this.apiRoot}/Tasks/${id}`;
  return this.http.delete(url);
}
/* #endregion */
}
