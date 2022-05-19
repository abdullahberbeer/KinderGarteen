export interface ClassForUsersDto{
  id:string,
  name:string,
  users:[
    {
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
    }
  ]
}
