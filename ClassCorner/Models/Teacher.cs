using System.ComponentModel.DataAnnotations.Schema;

namespace ClassCorner.Models
{
    public class Teacher
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }

    }
}