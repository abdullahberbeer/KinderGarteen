import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { User } from '../_models/user';
import { AlertifyService } from '../_services/alertify.service';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {
  userId: string | null | undefined;
  user:User={
    id:'',
    firstName:'',
    lastName:'',
    dateOfBirth:'',
    created:'',
    phone:'',
    profileImageUrl:'',
    adres:'',
    gender:'',
    role:'',
    classId:'',
    classes:{
      id:'',
      name:''
    }
  }
  displayProfileImageUrl = '';
  constructor(private userService:UserService,private route:ActivatedRoute,private alertfy:AlertifyService) { }

  ngOnInit(): void {
  this.route.paramMap.subscribe((params)=>{
    this.userId=params.get('id');
    this.userService.getUser(this.userId).subscribe((success)=>{
    this.user=success;
    this.setImage();
    })
  }


  )
  }
onUpdate(){
this.userService.updateUser(this.user.id,this.user).subscribe((success)=>{
  this.alertfy.success("Öğrenci güncelleme başarılı")
})
}
setImage(){
  if(this.user.profileImageUrl){
    this.displayProfileImageUrl=this.userService.getImagePath(this.user.profileImageUrl);
  }
  else{
    this.displayProfileImageUrl='assets/nouser.png'
  }
}
uploadImage(event:any){
  if(this.userId){
const file:File =event.target.files[0];
this.userService.uploadImage(this.user.id,file).subscribe((success)=>{
  this.user.profileImageUrl=success;
  this.setImage();
  this.alertfy.success("Fotoğraf başarılı bir şekilde yüklendi")
})
  }
}
}
