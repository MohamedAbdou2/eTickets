using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public class ActorService : EntityBaseRepository<Actor>, IActorService
    {

        public ActorService(AppDbContext context) : base(context) { }
    }
}
