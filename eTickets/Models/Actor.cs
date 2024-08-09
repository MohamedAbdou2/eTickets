using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor : IEntityBase
    {
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        [Required]
        public string ProfilePictureUrl { get; set; }
        [Display(Name = "Full Name")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        [Required]
        public string Bio { get; set; }

        //Relationships

        public virtual ICollection<ActorMovie> ActorMovie { get; set; } = new HashSet<ActorMovie>();
    }
}
