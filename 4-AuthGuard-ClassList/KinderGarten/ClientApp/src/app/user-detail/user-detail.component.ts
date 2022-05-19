import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { NoteaddComponent } from '../noteadd/noteadd.component';
import { NotelistComponent } from '../notelist/notelist.component';

import { Note } from '../_models/note';
import { User } from '../_models/user';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';
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
  note:Note={

    studentId:'',
    teacherId:'',

    point:0,
    periodId:'',
    lessonId:'',
    lesson:{
      id:'',
      name:''
    },period:{
      id:'',
      name:''
    }
  }
  displayProfileImageUrl = '';

  constructor(public authService:AuthService,private userService:UserService,private route:ActivatedRoute,
    private alertfy:AlertifyService,private router:Router,private modalService:NgbModal) { }

  ngOnInit(): void {
  this.route.paramMap.subscribe((params)=>{
    this.userId=params.get('id');
    this.userService.getUser(this.userId).subscribe((success)=>{
    this.user=success;
    this.note.studentId=this.user.id.toString();
    this.note.teacherId=this.authService.decodedToken.nameid;


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



openNoteAddModal(){
const modalRef=this.modalService.open(NoteaddComponent);
modalRef.componentInstance.studentId=this.user.id;

}
openNoteListModal(){

  const modalRef=this.modalService.open(NotelistComponent,{size:'lg'});

  modalRef.componentInstance.studentId=this.user.id;


}
}
