using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.Models;

namespace ServerApp.DTO
{
    public class ClassForListUsers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ClassForUserListDetail> Users { get; set; }
    }
}