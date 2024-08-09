using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public double Price { get; set; }

        //Relationships

        [ForeignKey("Movie")]
        public int MovieId { get; set; }

        public virtual Movie? Movie { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public virtual Order? Order { get; set; }


    }
}
