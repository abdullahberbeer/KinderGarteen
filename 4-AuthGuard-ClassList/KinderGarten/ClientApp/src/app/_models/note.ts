import { Lesson } from "./lesson"
import { Period } from "./period"

export interface Note{

  studentId:string,
  teacherId:string,

  point:number,
  periodId:string,
  lessonId:string,
  lesson:Lesson,
  period:Period
}
