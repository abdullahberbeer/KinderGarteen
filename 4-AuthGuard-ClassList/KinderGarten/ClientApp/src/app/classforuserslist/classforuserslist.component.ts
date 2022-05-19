import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { ClassForUsersDto } from '../DTO/classForUsersDto';
import { User } from '../_models/user';


import { AuthService } from '../_services/auth.service';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-classforuserslist',
  templateUrl: './classforuserslist.component.html',
  styleUrls: ['./classforuserslist.component.css']
})
export class ClassforuserslistComponent implements OnInit {

 classId:string|null|undefined;
 classes:ClassForUsersDto={
   id:'',
   name:'',
   users:[{
     id:'',
     firstName:'',
     lastName:'',
     dateOfBirth:'',
     created:'',
     phone:'',
     profileImageUrl:'',
     adres:'',
     gender:'',
     role:''
   }]
 };

 userss:any;
 displayedColumns: string[] = ['firstName', 'lastName', 'phone', 'gender','edit'];
  dataSource:MatTableDataSource<any>=new MatTableDataSource<any>();
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  filterString='';
  constructor(private userService:UserService,private authService:AuthService,private activatedRoute:ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe((params)=>{
      this.classId=params.get('id');
      this.userService.getClassForUsersById(this.classId).subscribe((success)=>{
        this.classes=success;
        this.userss=success.users;
        this.dataSource=new MatTableDataSource<any>(this.userss);
        this.dataSource.sortingDataAccessor=(item,property)=>{
          switch(property){
            case 'gender' : return item.gender;
            default:return property;
          }
        };
        this.dataSource.paginator=this.paginator;
        this.dataSource.sort=this.sort;
      })
    })
  }
  filterUsers(){
    this.dataSource.filter=this.filterString.trim().toLocaleLowerCase();
    // this.dataSource.filterPredicate = (data,filter)=>{
    //   return data.gender.toLocaleLowerCase().includes(filter)
    //   ||data.firstName.toLocaleLowerCase().includes(filter)
    //   ||data.lastName.toLocaleLowerCase().includes(filter)
    //   ||data.phone.toLocaleLowerCase().includes(filter)

    // }
  }


}
