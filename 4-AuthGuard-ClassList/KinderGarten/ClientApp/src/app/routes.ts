import { Routes } from "@angular/router";
import { AdminGuard } from "_guards/admin-guards";
import { TeacherGuard } from "_guards/teacher-guards";

import { ClassforuserslistComponent } from "./classforuserslist/classforuserslist.component";
import { ClasslistComponent } from "./classlist/classlist.component";
import { HomeComponent } from "./home/home.component";
import { RegisterComponent } from "./register/register.component";
import { UserDetailComponent } from "./user-detail/user-detail.component";
import { UserListComponent } from "./user-list/user-list.component";


export const appRoutes:Routes=[

    {path:"",component:HomeComponent},
    {path:"home",component:HomeComponent},
    {path:"users",component:UserListComponent,canActivate:[AdminGuard]},
     {path:"register",component:RegisterComponent,canActivate:[AdminGuard]},
     {path:"users/:id",component:UserDetailComponent,canActivate:[TeacherGuard]},
     {path:"classlist",component:ClasslistComponent,canActivate:[TeacherGuard]},
     {path:"classforuserslist/:id",component:ClassforuserslistComponent,canActivate:[TeacherGuard]},

    {path:"**",component:HomeComponent}


]
