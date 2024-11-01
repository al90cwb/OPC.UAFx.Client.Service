using System;
using Microsoft.EntityFrameworkCore;

namespace OPC.UAFx.Client.Service.Models;

public class AppDbContext : DbContext
    {
        public DbSet<MaquinaOee> MaquinaOees { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) // Construtor com opções
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source= MaquinaOee.db");
            }
        }
    }
