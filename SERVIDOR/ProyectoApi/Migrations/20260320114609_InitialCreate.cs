using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Imagen = table.Column<string>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Articulos",
                columns: new[] { "Id", "Imagen", "Nombre", "Stock" },
                values: new object[,]
                {
                    { 1, "/imagenes/teclado.jpg", "Teclado", 10 },
                    { 2, "/imagenes/raton.jpg", "Ratón", 25 },
                    { 3, "/imagenes/monitor.jpg", "Monitor", 8 },
                    { 4, "/imagenes/impresora.jpg", "Impresora", 5 },
                    { 5, "/imagenes/altavoces.jpg", "Altavoces", 12 },
                    { 6, "/imagenes/webcam.jpg", "Webcam", 18 },
                    { 7, "/imagenes/microfono.jpg", "Micrófono", 7 },
                    { 8, "/imagenes/portatil.jpg", "Portátil", 4 },
                    { 9, "/imagenes/tablet.jpg", "Tablet", 9 },
                    { 10, "/imagenes/discoduro.jpg", "Disco Duro", 15 },
                    { 11, "/imagenes/memoriausb.jpg", "Memoria USB", 30 },
                    { 12, "/imagenes/router.jpg", "Router", 6 },
                    { 13, "/imagenes/switch.jpg", "Switch", 11 },
                    { 14, "/imagenes/proyector.jpg", "Proyector", 3 },
                    { 15, "/imagenes/camara.jpg", "Cámara", 14 },
                    { 16, "/imagenes/smartphone.jpg", "Smartphone", 20 },
                    { 17, "/imagenes/auriculares.jpg", "Auriculares", 22 },
                    { 18, "/imagenes/cable hdmi.jpg", "Cable HDMI", 40 },
                    { 19, "/imagenes/cableusb.jpg", "Cable USB", 35 },
                    { 20, "/imagenes/tarjetagrafica.jpg", "Tarjeta Gráfica", 2 },
                    { 21, "/imagenes/fuentedepoder.jpg", "Fuente de Poder", 6 },
                    { 22, "/imagenes/placabase.jpg", "Placa Base", 5 },
                    { 23, "/imagenes/procesador.jpg", "Procesador", 7 },
                    { 24, "/imagenes/memoriaram.jpg", "Memoria RAM", 16 },
                    { 25, "/imagenes/ssd.jpg", "SSD", 13 },
                    { 26, "/imagenes/sillagaming.jpg", "Silla Gaming", 4 },
                    { 27, "/imagenes/mesa escritorio.jpg", "Mesa Escritorio", 3 },
                    { 28, "/imagenes/lamparaled.jpg", "Lámpara LED", 17 },
                    { 29, "/imagenes/regleta.jpg", "Regleta", 21 },
                    { 30, "/imagenes/adaptador.jpg", "Adaptador", 19 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articulos");
        }
    }
}
