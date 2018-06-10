using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Gestion.Models;

namespace Gestion.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>    {
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Campus> Campuses { get; set; }
        public DbSet<Aulas> Aulas { get; set; }
        public DbSet<Edificios> Edificios { get; set; }
		public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<TipoAula> TipoAulas { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Campus>().ToTable("CAMPUS");
            modelBuilder.Entity<Aulas>().ToTable("AULAS");
            modelBuilder.Entity<Edificios>().ToTable("EDIFICIOS");
            modelBuilder.Entity<Empleados>().ToTable("EMPLEADOS");
            modelBuilder.Entity<Usuarios>().ToTable("USUARIOS");
            modelBuilder.Entity<TipoAula>().ToTable("TIPO_AULA");
        }
    }


}
