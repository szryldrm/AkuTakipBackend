using System;
using System.Collections.Generic;
using System.Text;
using AkuTakip.Core.Utilities.Concrete;
using AkuTakip.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace AkuTakip.DataAccess.Concrete.EntityFramework.Contexts
{
    public class AkuTakipContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"server=(localdb)\mssqllocaldb;Database=AkuTakipDB;Trusted_Connection=true");
        }

        public DbSet<Plaka> Plaka { get; set; }
        public DbSet<AkuOzellik> AkuOzellik { get; set; }
        public DbSet<AkuTipi> AkuTipi { get; set; }
        public DbSet<Amper> Amper { get; set; }
        public DbSet<GarantiDetay> GarantiDetay { get; set; }
        public DbSet<GarantiDetayToAkuOzellik> GarantiDetayToAkuOzellik { get; set; }
        public DbSet<Marka> Marka { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
