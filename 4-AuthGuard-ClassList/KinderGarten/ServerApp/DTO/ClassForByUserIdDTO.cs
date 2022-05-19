using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.Models;

namespace ServerApp.DTO
{
    public class ClassForByUserIdDTO
    {
         public int Id { get; set; }
         public string Name { get; set; }
        
        public ICollection<User> Users { get; set; }
    }
}