import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";

import { AuthService } from "src/app/_services/auth.service";

 @Injectable({
  providedIn:'root'
 })
export class TeacherGuard implements CanActivate{
role:any;
 constructor(private authService:AuthService,private router:Router){

 }

 canActivate(){

  this.role=localStorage.getItem("role");

  if(this.role==='Müdür' || this.role==='Teacher'){

   return true
 }
 this.router.navigate(['/home'])
 return false;
 }
}
