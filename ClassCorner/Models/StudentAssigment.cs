using System.ComponentModel.DataAnnotations.Schema;

namespace ClassCorner.Models
{
    public class StudentAssigment
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [ForeignKey(nameof(Assigment))]
        public int AssigmentId { get; set; }
        public Assigment Assigment { get; set; }
    }
}