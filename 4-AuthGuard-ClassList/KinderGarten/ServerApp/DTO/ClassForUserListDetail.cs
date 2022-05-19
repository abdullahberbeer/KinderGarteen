using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.DTO
{
    public class ClassForUserListDetail
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; }
        public string Phone { get; set; }
        public string profileImageUrl { get; set; }
        public string Adres { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
    }
}