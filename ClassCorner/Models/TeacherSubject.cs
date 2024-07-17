using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassCorner.Models
{
    
    public class TeacherSubject
    {
        public int Id { get; set; }
        [ForeignKey(nameof (Teacher))]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        [ForeignKey(nameof (Subject))]
        public int SubjectId { get; set; }
       
        public Subject Subject { get; set; }
        
    }
}
