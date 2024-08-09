using eTickets.Data.Base;
using eTickets.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Movie : IEntityBase
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string? ImageUrl { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public MovieCategory MovieCategory { get; set; }

        //Relationships

        [ForeignKey("Cinema")]
        public int CinemaId { get; set; }

        public virtual Cinema? Cinema { get; set; }

        [ForeignKey("Producer")]
        public int ProducerId { get; set; }

        public virtual Producer? Producer { get; set; }

        public virtual ICollection<ActorMovie> ActorMovie { get; set; } = new HashSet<ActorMovie>();

    }
}
