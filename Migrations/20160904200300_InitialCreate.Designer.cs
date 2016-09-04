using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ConsoleApplication;

namespace efrepos.Migrations
{
    [DbContext(typeof(DemoContext))]
    [Migration("20160904200300_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConsoleApplication.ChildEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("ChildEntity");
                });

            modelBuilder.Entity("ConsoleApplication.MainEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ChildId");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.ToTable("MainEntity");
                });

            modelBuilder.Entity("ConsoleApplication.MainEntity", b =>
                {
                    b.HasOne("ConsoleApplication.ChildEntity", "Child")
                        .WithMany()
                        .HasForeignKey("ChildId");
                });
        }
    }
}
