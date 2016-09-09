using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ConsoleApplication;

namespace efrepos.Migrations
{
    [DbContext(typeof(DemoContext))]
    [Migration("20160909215952_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConsoleApplication.Colour", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Colour");
                });

            modelBuilder.Entity("ConsoleApplication.GeoArea", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<Guid?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("GeoArea");
                });

            modelBuilder.Entity("ConsoleApplication.ManufacturedIdentity", b =>
                {
                    b.Property<Guid>("WidgetId");

                    b.Property<Guid?>("ManufacturerId");

                    b.HasKey("WidgetId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("WidgetId")
                        .IsUnique();

                    b.ToTable("ManufacturedIdentity");
                });

            modelBuilder.Entity("ConsoleApplication.TechSpec", b =>
                {
                    b.Property<Guid>("WidgetId");

                    b.Property<bool>("DoesStuff");

                    b.HasKey("WidgetId");

                    b.HasIndex("WidgetId")
                        .IsUnique();

                    b.ToTable("TechSpec");
                });

            modelBuilder.Entity("ConsoleApplication.Widget", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ColourId")
                        .IsRequired();

                    b.Property<Guid?>("GeoAreaId");

                    b.HasKey("Id");

                    b.HasIndex("ColourId");

                    b.HasIndex("GeoAreaId");

                    b.ToTable("Widget");
                });

            modelBuilder.Entity("ConsoleApplication.WidgetManufacturer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("WidgetManufacturer");
                });

            modelBuilder.Entity("ConsoleApplication.GeoArea", b =>
                {
                    b.HasOne("ConsoleApplication.GeoArea", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("ConsoleApplication.ManufacturedIdentity", b =>
                {
                    b.HasOne("ConsoleApplication.WidgetManufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerId");

                    b.HasOne("ConsoleApplication.Widget", "Widget")
                        .WithOne("ManufacturedIdentity")
                        .HasForeignKey("ConsoleApplication.ManufacturedIdentity", "WidgetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ConsoleApplication.TechSpec", b =>
                {
                    b.HasOne("ConsoleApplication.Widget", "Widget")
                        .WithOne("TechSpec")
                        .HasForeignKey("ConsoleApplication.TechSpec", "WidgetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ConsoleApplication.Widget", b =>
                {
                    b.HasOne("ConsoleApplication.Colour", "Colour")
                        .WithMany()
                        .HasForeignKey("ColourId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ConsoleApplication.GeoArea", "GeoArea")
                        .WithMany()
                        .HasForeignKey("GeoAreaId");
                });
        }
    }
}
