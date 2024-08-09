using eTickets.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Data.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Movie Name")]
        public string? Name { get; set; }
        [Required]
        [Display(Name = "Movie Description")]

        public string? Description { get; set; }
        [Required]
        [Display(Name = "price in $")]

        public double Price { get; set; }
        [Required(ErrorMessage = "Movie Image URL is Required")]
        [Display(Name = "Movie Poster URL")]
        public string? ImageUrl { get; set; }
        [Required]
        [Display(Name = "Start Date")]

        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Movie Category is Required")]
        [Display(Name = "Select a Category")]


        public MovieCategory MovieCategory { get; set; }

        //Relationships

        [ForeignKey("Cinema")]

        [Display(Name = "Select Cinema")]
        [Required(ErrorMessage = "Movie cinema is required")]
        public int CinemaId { get; set; }



        [ForeignKey("Producer")]

        [Display(Name = "Select producer")]
        [Required(ErrorMessage = "Movie producer is required")]
        public int ProducerId { get; set; }

        [Display(Name = "Select Actor(s)")]
        [Required(ErrorMessage = "Movie actor(s) is required")]

        public virtual ICollection<int> ActorIds { get; set; } = new HashSet<int>();

    }
}
