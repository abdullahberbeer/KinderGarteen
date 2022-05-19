import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Lesson } from '../_models/lesson';
import { Note } from '../_models/note';
import { Period } from '../_models/period';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-noteadd',
  templateUrl: './noteadd.component.html',
  styleUrls: ['./noteadd.component.css']
})
export class NoteaddComponent implements OnInit {

  @Input() studentId!:string;

  userId: string | null | undefined;
  note:Note={

    studentId:'',
    teacherId:'',

    point:0,
    periodId:'1',
    lessonId:'1',
    lesson:{
      id:'',
      name:''
    },period:{
      id:'',
      name:''
    }
  }
  lessons:Lesson[]=[];
  periods:Period[]=[];
  constructor(private activeModal:NgbActiveModal,private authService:AuthService,private userService:UserService,private route:ActivatedRoute,
    private alertfy:AlertifyService,private router:Router) { }

  ngOnInit(): void {
    this.getLessons();
    this.getPeriods();
    this.note.studentId=this.studentId;
    this.note.teacherId=this.authService.decodedToken.nameid;

  }
  closeModal(){
    this.activeModal.close();
  }
  getLessons(){
    this.userService.getLesson().subscribe((success)=>{
      this.lessons=success;
    })
  }
  getPeriods(){
    this.userService.getPeriods().subscribe((success)=>{
      this.periods=success;
    })
  }
  noteAdd(){
    this.userService.noteAdded(this.note).subscribe((success)=>{

      this.alertfy.success("Not başarıyla eklendi")
      this.closeModal();
      this.router.navigate(['/users'])


    })
  }
}
