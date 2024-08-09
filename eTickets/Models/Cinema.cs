using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema : IEntityBase
    {
        public int Id { get; set; }
        [Required]
        public string? CinemaLogo { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }

        //Relationships

        public virtual ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();

    }
}
