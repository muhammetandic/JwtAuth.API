using System;

namespace JwtAuth.API.Data.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
