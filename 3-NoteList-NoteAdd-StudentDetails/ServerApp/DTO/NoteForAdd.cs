using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.DTO
{
    public class NoteForAdd
    {
             public int Id { get; set; }
        public int StudentId { get; set; }
    
        public int TeacherId { get; set; }
        
        public DateTime DateAdded { get; set; }=DateTime.Now;
        public double Point { get; set; }
        public int PeriodId { get; set; }
      
        public int LessonId { get; set; }
       
    }
}