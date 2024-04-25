using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtoServisSatis.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Markalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servisler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServisGelisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AracSorunu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServisUcreti = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServisCikisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YapılanIslemler = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GarantiKapsamındaMı = table.Column<bool>(type: "bit", nullable: false),
                    AracPlaka = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Marka = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Modeli = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KasaTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaseNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Acikalama = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servisler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sliderlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliderlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Araclar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Renk = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    KasaTipi = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ModelYili = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SatistaMi = table.Column<bool>(type: "bit", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Resim1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Resim2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Resim3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MarkaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Araclar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Araclar_Markalar_MarkaId",
                        column: x => x.MarkaId,
                        principalTable: "Markalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kullanicilar_Roller_RolId",
                        column: x => x.RolId,
                        principalTable: "Roller",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Musteriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    TcNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AracId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteriler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musteriler_Araclar_AracId",
                        column: x => x.AracId,
                        principalTable: "Araclar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Satislar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriId = table.Column<int>(type: "int", nullable: false),
                    AracId = table.Column<int>(type: "int", nullable: false),
                    SatisFiyati = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SatisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Satislar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Satislar_Araclar_AracId",
                        column: x => x.AracId,
                        principalTable: "Araclar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Satislar_Musteriler_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musteriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Musteriler",
                columns: new[] { "Id", "Aciklama", "Adi", "Adres", "AracId", "Mail", "Soyadi", "TcNo", "Telefon" },
                values: new object[] { 1, "Yok", "Ahmet", "İstanbul BeylikDüzü Gaziosmanpaşa bulvarı no:32/11", null, "ahmet4554@gmail.com", "Sayılı", "32419392922", "5554442134" });

            migrationBuilder.InsertData(
                table: "Roller",
                columns: new[] { "Id", "Adi" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Kullanicilar",
                columns: new[] { "Id", "Adi", "AktifMi", "EMail", "EklenmeTarihi", "KullaniciAdi", "RolId", "Sifre", "Soyadi", "Telefon" },
                values: new object[] { 1, "Enes", true, "admin@otoservis.com", new DateTime(2024, 3, 23, 21, 38, 10, 875, DateTimeKind.Local).AddTicks(7095), "admin", 1, "12345", "Kaya", "55544455454" });

            migrationBuilder.CreateIndex(
                name: "IX_Araclar_MarkaId",
                table: "Araclar",
                column: "MarkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_RolId",
                table: "Kullanicilar",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Musteriler_AracId",
                table: "Musteriler",
                column: "AracId");

            migrationBuilder.CreateIndex(
                name: "IX_Satislar_AracId",
                table: "Satislar",
                column: "AracId");

            migrationBuilder.CreateIndex(
                name: "IX_Satislar_MusteriId",
                table: "Satislar",
                column: "MusteriId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Satislar");

            migrationBuilder.DropTable(
                name: "Servisler");

            migrationBuilder.DropTable(
                name: "Sliderlar");

            migrationBuilder.DropTable(
                name: "Roller");

            migrationBuilder.DropTable(
                name: "Musteriler");

            migrationBuilder.DropTable(
                name: "Araclar");

            migrationBuilder.DropTable(
                name: "Markalar");
        }
    }
}
