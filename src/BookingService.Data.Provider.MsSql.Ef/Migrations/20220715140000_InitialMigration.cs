using System;
using LT.DigitalOffice.BookingService.Data.Provider.MsSql.Ef;
using LT.DigitalOffice.BookingService.Models.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LT.DigitalOffice.OfficeService.Data.Migrations
{
  [DbContext(typeof(BookingServiceDbContext))]
  [Migration("20220715140000_InitialMigration")]
  public class InitialCreate : Migration
  {
    #region Create tables

    private void CreateBookingsTable(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
        name: DbBooking.TableName,
        columns: table => new
        {
          Id = table.Column<Guid>(nullable: false),
          WorkspaceId = table.Column<Guid>(nullable: false),
          StartTime = table.Column<DateTime>(nullable: false),
          EndTime = table.Column<DateTime>(nullable: false),
          CreatedBy = table.Column<Guid>(nullable: false),
          CreatedAtUtc = table.Column<DateTime>(nullable: false),
          IsActive = table.Column<bool>(nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Bookings", x => x.Id);
        });
    }

    #endregion

    protected override void Up(MigrationBuilder migrationBuilder)
    {
      CreateBookingsTable(migrationBuilder);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(DbBooking.TableName);
    }
  }
}
