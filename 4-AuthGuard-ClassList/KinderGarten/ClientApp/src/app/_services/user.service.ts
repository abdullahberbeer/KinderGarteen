import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ClassForUsersDto } from '../DTO/classForUsersDto';
import { UserUpdateDTO } from '../DTO/userUpdateDto';
import { Classes } from '../_models/classes';
import { Lesson } from '../_models/lesson';
import { Note } from '../_models/note';
import { Period } from '../_models/period';
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
   getPeriods():Observable<Period[]>{
    return this.http.get<Period[]>(this.baseUrl+'/Users/periods');
  }
  getLesson():Observable<Lesson[]>{
    return this.http.get<Lesson[]>(this.baseUrl+'/Users/lessons');
  }
  getUser(userId:string|null):Observable<User>{
    return this.http.get<User>(this.baseUrl+"/Users/"+userId);
  }
  getByNot(studentId:string|null):Observable<Note[]>{
    return this.http.get<Note[]>(this.baseUrl+"/Users/note/"+studentId);
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
  noteAdded(model:Note):Observable<Note>{
    return this.http.post<Note>(this.baseUrl+"/Users/addnote",model);
  }
  getClassById(teacherId:string){
    return this.http.get<Classes[]>(this.baseUrl+"/Users/classes/"+teacherId);
  }
  getClassForUsersById(classId:string|null):Observable<ClassForUsersDto>{
    return this.http.get<ClassForUsersDto>(this.baseUrl+"/Users/classesforlistuser/"+classId);
  }
}
