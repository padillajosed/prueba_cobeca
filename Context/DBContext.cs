using apiInscripcion.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace apiInscripcion.Context
{
    public class InsDBContext : DbContext
    {
        public InsDBContext(DbContextOptions<InsDBContext> options): base(options)
        {

        }

        public DbSet<Inscripcion> inscripcion { get; set; }
    }
}
