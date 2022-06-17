using BackEventos.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEventos
{
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
            public DbSet<Event> Evento { get; set; }
    }
}
