using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace testurl3.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GtMetrics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Status = table.Column<string>(nullable: true),
                    Error = table.Column<string>(nullable: true),
                    ReportUrl = table.Column<string>(nullable: true),
                    PageSpeedScore = table.Column<int>(nullable: true),
                    YSlowScore = table.Column<int>(nullable: true),
                    HtmlBytes = table.Column<int>(nullable: true),
                    HtmlLoadTime = table.Column<int>(nullable: true),
                    PageBytes = table.Column<int>(nullable: true),
                    PageLoadTime = table.Column<int>(nullable: true),
                    PageElements = table.Column<int>(nullable: true),
                    RedirectDuration = table.Column<int>(nullable: true),
                    ConnectionDuration = table.Column<int>(nullable: true),
                    BackendDuration = table.Column<int>(nullable: true),
                    FirstPaintTime = table.Column<int>(nullable: true),
                    FirstContentfulPaintTime = table.Column<int>(nullable: true),
                    DomInteractiveTime = table.Column<int>(nullable: true),
                    DomContentLoadedTime = table.Column<int>(nullable: true),
                    DomContentLoadedDuration = table.Column<int>(nullable: true),
                    OnloadTime = table.Column<int>(nullable: true),
                    FullyLoadedTime = table.Column<int>(nullable: true),
                    RumSpeedIndex = table.Column<int>(nullable: true),
                    Screenshot = table.Column<string>(nullable: true),
                    HARFile = table.Column<string>(nullable: true),
                    PageSpeed = table.Column<string>(nullable: true),
                    PageSpeedFiles = table.Column<string>(nullable: true),
                    YSlow = table.Column<string>(nullable: true),
                    ReportPdf = table.Column<string>(nullable: true),
                    ReportPdfFull = table.Column<string>(nullable: true),
                    Video = table.Column<string>(nullable: true),
                    FilmStrip = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GtMetrics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BusinessType = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    SfVersion = table.Column<double>(nullable: false),
                    EndEnterpriseSupport = table.Column<DateTime>(nullable: true),
                    SitefinityRetirmentDate = table.Column<DateTime>(nullable: true),
                    PreviousVersion = table.Column<double>(nullable: true),
                    ConfirmedVersionDate = table.Column<DateTime>(nullable: false),
                    Contacted = table.Column<bool>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    RankingScale = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    State_Region = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    GtMetricsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_GtMetrics_GtMetricsId",
                        column: x => x.GtMetricsId,
                        principalTable: "GtMetrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_GtMetricsId",
                table: "Companies",
                column: "GtMetricsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "GtMetrics");
        }
    }
}
