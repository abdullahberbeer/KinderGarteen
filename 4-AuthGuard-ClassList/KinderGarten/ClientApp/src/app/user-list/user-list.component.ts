import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  users:User[]=[];
  displayedColumns: string[] = ['firstName', 'lastName', 'phone', 'gender','edit'];
  dataSource:MatTableDataSource<User>=new MatTableDataSource<User>();
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  filterString='';
  constructor(private userService:UserService) { }

  ngOnInit(): void {

    this.getUsers();

  }

  getUsers(){
    this.userService.getUsers().subscribe((success)=>{
      this.users=success;
      this.dataSource=new MatTableDataSource<User>(this.users);
      this.dataSource.sortingDataAccessor=(item,property)=>{
        switch(property){
          case 'gender' : return item.gender;
          default:return property;
        }
      };
      this.dataSource.paginator=this.paginator;
      this.dataSource.sort=this.sort;
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
