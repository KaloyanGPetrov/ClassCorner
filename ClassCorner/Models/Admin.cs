using System.ComponentModel.DataAnnotations.Schema;

namespace ClassCorner.Models
{
    public class Admin
    {
        public int Id { get; set; }
        [ForeignKey(nameof(AppUser))]
        public int AppUserId {  get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
