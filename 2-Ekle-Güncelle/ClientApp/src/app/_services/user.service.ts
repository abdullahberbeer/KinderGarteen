import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserUpdateDTO } from '../DTO/userUpdateDto';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {


 baseUrl:string='https://localhost:5001'
  constructor(private http:HttpClient) { }
  getUsers():Observable<User[]>{
    return this.http.get<User[]>(this.baseUrl+'/Users');
  }
  getUser(userId:string|null):Observable<User>{
    return this.http.get<User>(this.baseUrl+"/Users/"+userId);
  }
  updateUser(userId:string,userRequest:User):Observable<User>{
    const updateUserRequest:UserUpdateDTO={
      firstName:userRequest.firstName,
      lastName:userRequest.lastName,
      dateOfBirth:userRequest.dateOfBirth,
      created:userRequest.created,
      phone:userRequest.phone,
      adres:userRequest.adres,
      gender:userRequest.gender,
      role:userRequest.role,
      classId:userRequest.classId

    };

    return this.http.put<User>(this.baseUrl+'/Users/'+userId,updateUserRequest);
  }
  getImagePath(releativePath:string){
    return `${this.baseUrl}/${releativePath}`;
  }
  uploadImage(userId:string,file:File){
    const formData = new FormData();
    formData.append("profileImage",file);

    return this.http.post(this.baseUrl+'/Users/'+userId+'/upload-image',formData,{
      responseType:'text'
    })
  }
}
