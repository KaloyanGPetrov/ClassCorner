using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace ClassCorner.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public DateOnly Birthday { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        [ForeignKey(nameof (AppUser))]
        public int UserId { get; set; }
        public AppUser AppUser { get; set; }


    }
}
