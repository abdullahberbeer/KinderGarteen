import { Classes } from "./classes";

export interface User {
  id:string,
  firstName:string,
  lastName:string,
  dateOfBirth:string,
  created:string,
  phone:string,
  profileImageUrl:string,
  adres:string,
  gender:string,
  role:string,
  classId:string,
  classes:Classes
}
