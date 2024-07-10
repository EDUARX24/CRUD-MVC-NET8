using CrudNet8MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudNet8MVC.Datos
{
    public class ApplicationDbContext : DbContext
    {
        //costructor dependencias
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }
        //agregar los modelos, cada modelo corresponde a una tabla
        public DbSet<Contacto> Contacto { get; set; }
    }
}
