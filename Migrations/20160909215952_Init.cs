using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace efrepos.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colour",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colour", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeoArea",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoArea", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeoArea_GeoArea_ParentId",
                        column: x => x.ParentId,
                        principalTable: "GeoArea",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WidgetManufacturer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidgetManufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Widget",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ColourId = table.Column<Guid>(nullable: false),
                    GeoAreaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Widget", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Widget_Colour_ColourId",
                        column: x => x.ColourId,
                        principalTable: "Colour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Widget_GeoArea_GeoAreaId",
                        column: x => x.GeoAreaId,
                        principalTable: "GeoArea",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManufacturedIdentity",
                columns: table => new
                {
                    WidgetId = table.Column<Guid>(nullable: false),
                    ManufacturerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturedIdentity", x => x.WidgetId);
                    table.ForeignKey(
                        name: "FK_ManufacturedIdentity_WidgetManufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "WidgetManufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManufacturedIdentity_Widget_WidgetId",
                        column: x => x.WidgetId,
                        principalTable: "Widget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechSpec",
                columns: table => new
                {
                    WidgetId = table.Column<Guid>(nullable: false),
                    DoesStuff = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechSpec", x => x.WidgetId);
                    table.ForeignKey(
                        name: "FK_TechSpec_Widget_WidgetId",
                        column: x => x.WidgetId,
                        principalTable: "Widget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeoArea_ParentId",
                table: "GeoArea",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturedIdentity_ManufacturerId",
                table: "ManufacturedIdentity",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturedIdentity_WidgetId",
                table: "ManufacturedIdentity",
                column: "WidgetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TechSpec_WidgetId",
                table: "TechSpec",
                column: "WidgetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Widget_ColourId",
                table: "Widget",
                column: "ColourId");

            migrationBuilder.CreateIndex(
                name: "IX_Widget_GeoAreaId",
                table: "Widget",
                column: "GeoAreaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManufacturedIdentity");

            migrationBuilder.DropTable(
                name: "TechSpec");

            migrationBuilder.DropTable(
                name: "WidgetManufacturer");

            migrationBuilder.DropTable(
                name: "Widget");

            migrationBuilder.DropTable(
                name: "Colour");

            migrationBuilder.DropTable(
                name: "GeoArea");
        }
    }
}
