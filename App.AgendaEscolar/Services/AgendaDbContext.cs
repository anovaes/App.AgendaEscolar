using App.AgendaEscolar.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.AgendaEscolar.Services
{
    public class AgendaDbContext : DbContext
    {
        public DbSet<Compromisso> Compromisso { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Agenda.db");
        }
    }
}
