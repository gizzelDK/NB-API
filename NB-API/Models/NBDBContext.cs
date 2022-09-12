using Microsoft.EntityFrameworkCore;

namespace NB_API.Models
{
    public partial class NBDBContext : DbContext
    {
        public NBDBContext(DbContextOptions<NBDBContext> options) : base(options)
        {
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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UserAPI;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //        //optionsBuilder.UseSqlServer("Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = master; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        //        //optionsBuilder.UseSqlServer("Data Source=MININT-AVDHD5F\\MSSQLSERVER2019;Initial Catalog=UserAPI;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //    }
        //} 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rolle>().HasData(
                new Rolle { Id = 1, Level = 0, RolleNavn = RolleNavn.AnonymBruger },
                new Rolle { Id = 2, Level = 10, RolleNavn = RolleNavn.Bruger },
                new Rolle { Id = 3, Level = 20, RolleNavn = RolleNavn.Administrator });
            // modelBuilder.Entity<Rolle>().Property(x => x.RolleNavn).HasDefaultValue(RolleNavn.AnonymBruger);
            modelBuilder.Entity<Login>()
               .Property(p => p.LoginTime)
               .HasComputedColumnSql("getutcdate()")
               .ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Bruger>().Navigation(b => b.Kontaktoplysninger).AutoInclude();
            modelBuilder.Entity<Kontaktoplysninger>().Navigation(b => b.Bryggeri).AutoInclude();
            modelBuilder.Entity<Øl>().Navigation(b => b.Bryggeri).AutoInclude();
            modelBuilder.Entity<Bruger>().Navigation(b => b.Rolle).AutoInclude();
            modelBuilder.Entity<Forum>().Navigation(f => f.Posts).AutoInclude();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
