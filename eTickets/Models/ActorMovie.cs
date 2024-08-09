using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class ActorMovie
    {
        [ForeignKey("Actor")]
        public int ActorId { get; set; }

        public virtual Actor? Actor { get; set; }

        [ForeignKey("Movie")]
        public int MovieId { get; set; }

        public virtual Movie? Movie { get; set; }
    }
}
