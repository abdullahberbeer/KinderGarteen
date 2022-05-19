import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Classes } from '../_models/classes';
import { AuthService } from '../_services/auth.service';

import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-classlist',
  templateUrl: './classlist.component.html',
  styleUrls: ['./classlist.component.css']
})
export class ClasslistComponent implements OnInit {

  classes:Classes[]=[];
  constructor(private userService:UserService,private authService:AuthService,private activatedRoute:ActivatedRoute) { }

  ngOnInit(): void {

   this.getClassByIdTeacher();
  }

  getClassByIdTeacher(){
    this.userService.getClassById(this.authService.decodedToken.nameid).subscribe((success)=>{
      this.classes=success;
    })
  }
}
