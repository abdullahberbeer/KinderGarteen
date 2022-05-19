import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
baseUrl:string='https://localhost:5001/api/auth/';
jwtHelper = new JwtHelperService();
decodedToken:any;
role:any;
opened:string='';
  constructor(private http:HttpClient) { }

  login(model:any){
    return this.http.post(this.baseUrl+"login",model).pipe(
      map((response:any)=>{
        const result = response;
        if(result){
          localStorage.setItem("token", result.token);
          localStorage.setItem("role", result.role);
          this.decodedToken=this.jwtHelper.decodeToken(result.token)
          this.role=localStorage.getItem(result.role)

          if(result.role==='Müdür'){
            this.opened='Müdür';
          }else if(result.role==='Student'){
            this.opened='Student'
          }else if(result.role==='Teacher'){
            this.opened='Teacher'
          }else{
            this.opened='';
          }

          this.opened=result.role;
          console.log(this.opened)



        }
      })
    )
  }
  register(model:any){
    return this.http.post(this.baseUrl+"register",model);
  }
  loggedIn(){
    const token = localStorage.getItem("token")
    return !this.jwtHelper.isTokenExpired(token!);
  }

    logout(){
      localStorage.removeItem("token")
      localStorage.removeItem("role")
      this.opened='';
    }


}
