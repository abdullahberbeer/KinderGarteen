using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class Note
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public User Student { get; set; }
        public int TeacherId { get; set; }
        public User Teacher { get; set; }
        public DateTime DateAdded { get; set; }
        public double Point { get; set; }
        public int PeriodId { get; set; }
        public Period Period { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
      


    }
}