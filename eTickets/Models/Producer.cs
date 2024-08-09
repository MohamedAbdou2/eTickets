using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer : IEntityBase
    {
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        [Required]
        public string? ProfilePictureUrl { get; set; }
        [Display(Name = "Full Name")]
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "full Name must Be between 3 and 50 letters")]
        public string? FullName { get; set; }
        [Display(Name = "Biography")]
        [Required]
        public string? Bio { get; set; }

        //Relationships

        public virtual ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();

    }
}
