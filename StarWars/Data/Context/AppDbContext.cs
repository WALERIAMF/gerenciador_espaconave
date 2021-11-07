using Microsoft.EntityFrameworkCore;
using StarWars.Models;

namespace StarWars.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<NaveModel>()
            //    .HasOne(nave => nave.Piloto)
            //    .WithMany(piloto => piloto.Naves)
            //    .HasForeignKey(nave => nave.Id);

            //builder.Entity<PlanetaModel>()
            //    .HasOne(planeta => planeta.Piloto)
            //    .WithMany(piloto => piloto.Planetas)
            //    .HasForeignKey(planeta => planeta.Id);

            builder.Entity<NavePilotoModel>()
                .HasOne(nave => nave.Nave)
                .WithMany(navepiloto => navepiloto.NavePilotos)
                .HasForeignKey(navepiloto => navepiloto.IdNave);

            builder.Entity<NavePilotoModel>()
                .HasOne(nave => nave.Piloto)
                .WithMany(navepiloto => navepiloto.NavePilotos)
                .HasForeignKey(navepiloto => navepiloto.IdPiloto);

            builder.Entity<PilotoPlanetaModel>()
                .HasOne(nave => nave.Nave)
                .WithMany(pilotoplaneta => pilotoplaneta.PilotoPlanetas)
                .HasForeignKey(navepiloto => navepiloto.IdPiloto);

            builder.Entity<PilotoPlanetaModel>()
                .HasOne(nave => nave.Piloto)
                .WithMany(pilotoplaneta => pilotoplaneta.PilotoPlanetas)
                .HasForeignKey(navepiloto => navepiloto.IdPlaneta);

        }

        public DbSet<NaveModel> Naves { get; set; }
        public DbSet<PilotoModel> Pilotos { get; set; }
        public DbSet<PlanetaModel> Planetas { get; set; }
        public DbSet<NavePilotoModel> NavePilotos { get; set; }
        public DbSet<PilotoPlanetaModel> PilotoPlanetas { get; set; }
    }
}
