using Microsoft.EntityFrameworkCore;
using MyAppData.Entities;

namespace MyAppData.Data
{
    public class SystemDbContext : DbContext
    {
        public SystemDbContext(DbContextOptions<SystemDbContext> options)
            : base(options) { }

        public DbSet<Cours> Cours => Set<Cours>();
        public DbSet<Etudiant> Etudiants => Set<Etudiant>();
        public DbSet<Disponibilite> Disponibilites => Set<Disponibilite>();
        public DbSet<Local> Locaux => Set<Local>();
        public DbSet<HoraireLocal> HorairesLocaux => Set<HoraireLocal>();
        public DbSet<GroupeEtude> Groupes => Set<GroupeEtude>();
        public DbSet<Utilisateur> Utilisateurs => Set<Utilisateur>();

    }
}