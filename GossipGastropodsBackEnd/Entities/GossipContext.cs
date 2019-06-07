using Microsoft.EntityFrameworkCore;

namespace GossipGastropodsBackEnd.Entities
{
    public class GossipContext : DbContext
    {
        public GossipContext(DbContextOptions<GossipContext> options) : base(options) { }
    }
}
