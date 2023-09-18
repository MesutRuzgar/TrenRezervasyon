using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class Context : DbContext
    {
        public DbSet<Tren> Trenler { get; set; }
        public DbSet<Vagon> Vagonlar { get; set; }
        public DbSet<RezervasyonIstegi> rezervasyonIstekleri { get; set; }
        public DbSet<YerlesimAyrinti> YerlesimAyrintilari { get; set; }
        public DbSet<RezervasyonSonucu> RezervasyonSonuclari { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=TrenRezervasyonu;TrustServerCertificate=True;integrated security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Tren>().HasData(
                new Tren { TrenID = 1, Ad = "Başkent Ekspres" }          
               
            );


            modelBuilder.Entity<Vagon>().HasData(
                new Vagon { VagonID = 1, Ad = "Vagon 1", Kapasite = 100, DoluKoltukAdet = 68, TrenID = 1 },
                new Vagon { VagonID = 2, Ad = "Vagon 2", Kapasite = 90, DoluKoltukAdet = 50, TrenID = 1 },
                new Vagon { VagonID = 3, Ad = "Vagon 3", Kapasite = 60, DoluKoltukAdet = 60, TrenID = 1 },
                new Vagon { VagonID = 4, Ad = "Vagon 4", Kapasite = 70, DoluKoltukAdet = 25, TrenID = 1 }
            );
        }
    }
}
