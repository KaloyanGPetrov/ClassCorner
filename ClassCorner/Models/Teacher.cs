using System.ComponentModel.DataAnnotations.Schema;

namespace ClassCorner.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [ForeignKey(nameof(AppUser))]
        public int AppId { get; set; }
        public AppUser AppUser { get; set; }

    }
}
