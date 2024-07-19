using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace ClassCorner.Models
{
    public class Student
    {
        
        public string Id { get; set; }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string ClassName { get; set; }
        public DateOnly? Birthday { get; set; }
        //public int ClassId { get; set; }
        //public Class Class { get; set; }


    }
}
