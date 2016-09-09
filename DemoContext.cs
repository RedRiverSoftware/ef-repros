using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApplication
{
    public class DemoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DemoRepro2;Trusted_Connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Widget>()
                .HasOne(b => b.Colour).WithMany().IsRequired();

            builder.Entity<Widget>()
                .HasOne(b => b.GeoArea).WithMany().IsRequired(false);

            builder.Entity<Widget>()
                .HasOne(b => b.ManufacturedIdentity).WithOne(i => i.Widget).HasForeignKey<ManufacturedIdentity>(i => i.WidgetId).IsRequired(true);

            builder.Entity<Widget>()
                .HasOne(b => b.TechSpec).WithOne(i => i.Widget).HasForeignKey<TechSpec>(i => i.WidgetId).IsRequired(true);

            builder.Entity<GeoArea>()
                .HasMany(h => h.Children).WithOne(h => h.Parent).IsRequired(false);

            builder.Entity<ManufacturedIdentity>()
                .HasKey(c => c.WidgetId);
                
            builder.Entity<TechSpec>()
                .HasKey(c => c.WidgetId);
        }
    }

    public class Widget
    {
        public Guid Id { get; set; }
        public GeoArea GeoArea { get; set; } 
        public TechSpec TechSpec { get; set; }
        public ManufacturedIdentity ManufacturedIdentity { get; set; }
        public Colour Colour { get; set; }
    }

    public class Colour
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class ManufacturedIdentity
    {
        public Widget Widget { get; set; }
        public Guid WidgetId { get; set; }
        public WidgetManufacturer Manufacturer { get; set; }
    }

    public class TechSpec
    {
        public Widget Widget { get; set; }
        public Guid WidgetId { get; set; }
        public bool DoesStuff { get; set; }
    }

    public class WidgetManufacturer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class GeoArea
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<GeoArea> Children { get; set; }
        public GeoArea Parent { get; set; }
        public Guid? ParentId { get; set; }
    }
}