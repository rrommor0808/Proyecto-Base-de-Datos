using Microsoft.EntityFrameworkCore;
using ProyectoAPI.Models;

namespace ProyectoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Articulo> Articulos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulo>().HasData(
                new Articulo { Id = 1, Imagen = "/imagenes/teclado.jpg", Nombre = "Teclado", Stock = 10 },
                new Articulo { Id = 2, Imagen = "/imagenes/raton.jpg", Nombre = "Ratón", Stock = 25 },
                new Articulo { Id = 3, Imagen = "/imagenes/monitor.jpg", Nombre = "Monitor", Stock = 8 },
                new Articulo { Id = 4, Imagen = "/imagenes/impresora.jpg", Nombre = "Impresora", Stock = 5 },
                new Articulo { Id = 5, Imagen = "/imagenes/altavoces.jpg", Nombre = "Altavoces", Stock = 12 },
                new Articulo { Id = 6, Imagen = "/imagenes/webcam.jpg", Nombre = "Webcam", Stock = 18 },
                new Articulo { Id = 7, Imagen = "/imagenes/microfono.jpg", Nombre = "Micrófono", Stock = 7 },
                new Articulo { Id = 8, Imagen = "/imagenes/portatil.jpg", Nombre = "Portátil", Stock = 4 },
                new Articulo { Id = 9, Imagen = "/imagenes/tablet.jpg", Nombre = "Tablet", Stock = 9 },
                new Articulo { Id = 10, Imagen = "/imagenes/discoduro.jpg", Nombre = "Disco Duro", Stock = 15 },
                new Articulo { Id = 11, Imagen = "/imagenes/memoriausb.jpg", Nombre = "Memoria USB", Stock = 30 },
                new Articulo { Id = 12, Imagen = "/imagenes/router.jpg", Nombre = "Router", Stock = 6 },
                new Articulo { Id = 13, Imagen = "/imagenes/switch.jpg", Nombre = "Switch", Stock = 11 },
                new Articulo { Id = 14, Imagen = "/imagenes/proyector.jpg", Nombre = "Proyector", Stock = 3 },
                new Articulo { Id = 15, Imagen = "/imagenes/camara.jpg", Nombre = "Cámara", Stock = 14 },
                new Articulo { Id = 16, Imagen = "/imagenes/smartphone.jpg", Nombre = "Smartphone", Stock = 20 },
                new Articulo { Id = 17, Imagen = "/imagenes/auriculares.jpg", Nombre = "Auriculares", Stock = 22 },
                new Articulo { Id = 18, Imagen = "/imagenes/cable hdmi.jpg", Nombre = "Cable HDMI", Stock = 40 },
                new Articulo { Id = 19, Imagen = "/imagenes/cableusb.jpg", Nombre = "Cable USB", Stock = 35 },
                new Articulo { Id = 20, Imagen = "/imagenes/tarjetagrafica.jpg", Nombre = "Tarjeta Gráfica", Stock = 2 },
                new Articulo { Id = 21, Imagen = "/imagenes/fuentedepoder.jpg", Nombre = "Fuente de Poder", Stock = 6 },
                new Articulo { Id = 22, Imagen = "/imagenes/placabase.jpg", Nombre = "Placa Base", Stock = 5 },
                new Articulo { Id = 23, Imagen = "/imagenes/procesador.jpg", Nombre = "Procesador", Stock = 7 },
                new Articulo { Id = 24, Imagen = "/imagenes/memoriaram.jpg", Nombre = "Memoria RAM", Stock = 16 },
                new Articulo { Id = 25, Imagen = "/imagenes/ssd.jpg", Nombre = "SSD", Stock = 13 },
                new Articulo { Id = 26, Imagen = "/imagenes/sillagaming.jpg", Nombre = "Silla Gaming", Stock = 4 },
                new Articulo { Id = 27, Imagen = "/imagenes/mesa escritorio.jpg", Nombre = "Mesa Escritorio", Stock = 3 },
                new Articulo { Id = 28, Imagen = "/imagenes/lamparaled.jpg", Nombre = "Lámpara LED", Stock = 17 },
                new Articulo { Id = 29, Imagen = "/imagenes/regleta.jpg", Nombre = "Regleta", Stock = 21 },
                new Articulo { Id = 30, Imagen = "/imagenes/adaptador.jpg", Nombre = "Adaptador", Stock = 19 }
            );
        }
    }
}
