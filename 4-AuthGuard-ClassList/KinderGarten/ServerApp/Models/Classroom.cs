using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class Classroom
    {
     public int Id { get; set; }   
     public string Name { get; set; }  
    
   public ICollection<User> User { get; set; }
  
    }
}