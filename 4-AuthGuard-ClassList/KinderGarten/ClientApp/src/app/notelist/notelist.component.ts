import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

import { Note } from '../_models/note';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-notelist',
  templateUrl: './notelist.component.html',
  styleUrls: ['./notelist.component.css']
})
export class NotelistComponent implements OnInit {

  @Input() studentId!:string;
  notes:Note[]=[];

  displayedColumns: string[] = ['periodId', 'lessonId','point', 'edit'];
  dataSource:MatTableDataSource<Note>=new MatTableDataSource<Note>();
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  filterString='';

  constructor(private userService:UserService,private aroute:ActivatedRoute,private activeModal:NgbActiveModal) { }






  ngOnInit(): void {
this.getNotes();

  }


getNotes(){
  this.userService.getByNot(this.studentId).subscribe((success)=>{
  this.notes=success;

  this.dataSource=new MatTableDataSource<Note>(this.notes);

  this.dataSource.paginator=this.paginator;
  this.dataSource.sort=this.sort;
  })
}

filterNotes(){
   this.dataSource.filter=this.filterString.trim().toLocaleLowerCase();
  this.dataSource.filterPredicate=(data,filter)=>{
    return data.lesson.name.toLocaleLowerCase().includes(filter)||
    data.period.name.toLocaleLowerCase().includes(filter)||
    data.point.toLocaleString().includes(filter)
  }
  // this.dataSource.filterPredicate = (data,filter)=>{
  //   return data.gender.toLocaleLowerCase().includes(filter)
  //   ||data.firstName.toLocaleLowerCase().includes(filter)
  //   ||data.lastName.toLocaleLowerCase().includes(filter)
  //   ||data.phone.toLocaleLowerCase().includes(filter)

  // }
}
closeModal(){
  this.activeModal.close()
}
}
