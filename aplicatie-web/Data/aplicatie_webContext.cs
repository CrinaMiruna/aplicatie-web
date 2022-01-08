using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using aplicatie_web.Models;

namespace aplicatie_web.Data
{
    public class aplicatie_webContext : DbContext
    {
        public aplicatie_webContext (DbContextOptions<aplicatie_webContext> options)
            : base(options)
        {
        }

        public DbSet<aplicatie_web.Models.Programare> Programare { get; set; }

        public DbSet<aplicatie_web.Models.Salon> Salon { get; set; }

        public DbSet<aplicatie_web.Models.ProgramareCategory> ProgramareCategory { get; set; }
    }
}
