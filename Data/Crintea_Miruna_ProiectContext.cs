using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Crintea_Miruna_Proiect.Models;

namespace Crintea_Miruna_Proiect.Data
{
    public class Crintea_Miruna_ProiectContext : DbContext
    {
        public Crintea_Miruna_ProiectContext (DbContextOptions<Crintea_Miruna_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Crintea_Miruna_Proiect.Models.Skater> Skater { get; set; } = default!;

        public DbSet<Crintea_Miruna_Proiect.Models.Element>? Element { get; set; }

        public DbSet<Crintea_Miruna_Proiect.Models.Coach>? Coach { get; set; }

        public DbSet<Crintea_Miruna_Proiect.Models.SkaterCoach>? SkaterCoach { get; set; }

        public DbSet<Crintea_Miruna_Proiect.Models.SkatingClub>? SkatingClub { get; set; }

        public DbSet<Crintea_Miruna_Proiect.Models.ProgramElement>? ProgramElement { get; set; }
    }
}
