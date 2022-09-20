using Microsoft.EntityFrameworkCore;
using NB_API.Services;
using NB_API.Models;

namespace NB_API.Models
{
    public partial class NBDBContext : DbContext
    {
        private IHashingService _hashingService;
        private ICryptoService _cryptoService;
        public NBDBContext(DbContextOptions<NBDBContext> options, IHashingService hashingService, ICryptoService cryptoService) : base(options)
        {
            _hashingService = hashingService;
            _cryptoService = cryptoService;
        }

        public virtual DbSet<Kontaktoplysninger> Kontaktoplysninger { get; set; }
        public virtual DbSet<Rolle> Rolle { get; set; }
        public virtual DbSet<Bruger> Bruger { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<Forum> Forum { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Øl> Øl { get; set; }
        public virtual DbSet<Samarbejde> Samarbejde { get; set; }
        public virtual DbSet<Certifikat> Certifikat { get; set; }
        public virtual DbSet<Bryggeri> Bryggeri { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<SamarbejdeAnmodning> SamarbejdeAnmodning { get; set; }
        public virtual DbSet<Kommentar> Kommentar { get; set; }
        public virtual DbSet<Opskrift> Opskrift { get; set; }
        public virtual DbSet<Rapport> Rapport { get; set; }
        public virtual DbSet<Deltager> Deltager { get; set; }
        public virtual DbSet<ØlTags> ØlTags { get; set; }
        public virtual DbSet<ForumTags> ForumTags { get; set; }
        public virtual DbSet<EventTags> EventTags { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            IHashingService hashingService;
            modelBuilder.Entity<Rolle>().HasData(
                new Rolle { Id = 1, Level = 0, RolleNavn = RolleNavn.AnonymBruger },
                new Rolle { Id = 2, Level = 10, RolleNavn = RolleNavn.Bruger },
                new Rolle { Id = 3, Level = 20, RolleNavn = RolleNavn.Administrator });
            // modelBuilder.Entity<Rolle>().Property(x => x.RolleNavn).HasDefaultValue(RolleNavn.AnonymBruger);

            modelBuilder.Entity<Bruger>().Navigation(b => b.Kontaktoplysninger).AutoInclude();
            modelBuilder.Entity<Bruger>().Navigation(b => b.Rolle).AutoInclude();
            modelBuilder.Entity<Kontaktoplysninger>().Navigation(b => b.Bryggeri).AutoInclude();
            modelBuilder.Entity<Bryggeri>().Navigation(b => b.Kontaktoplysninger).AutoInclude();
            modelBuilder.Entity<Forum>().Navigation(f => f.Posts).AutoInclude();
            modelBuilder.Entity<Øl>().Navigation(b => b.Bryggeri).AutoInclude();
            modelBuilder.Entity<Øl>().Navigation(f => f.Kommentarer).AutoInclude();
            modelBuilder.Entity<Deltager>().HasKey(de => de.Id);
            modelBuilder.Entity<ØlTags>().HasKey(øt => øt.Id);
            modelBuilder.Entity<ForumTags>().HasKey(ft => ft.Id);
            modelBuilder.Entity<EventTags>().HasKey(et => et.Id);

            Array adminSalt = _hashingService.CreateHash("admin");
            
            modelBuilder.Entity<Bruger>().HasData(
                new Bruger { 
                            Id = 1, 
                            Brugernavn = _cryptoService.encrypt("admin"), 
                            RolleId = 3, 
                            PwSalt = (byte[])adminSalt.GetValue(0), 
                            PwHash = (byte[])adminSalt.GetValue(1)
                });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
