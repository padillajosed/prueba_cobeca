using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiInscripcion.Models
{
    public class Inscripcion
    {
        [Key]
        public int id { get; set;} 

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Identificacion { get; set; }
        public int Edad { get; set; }
        public string Casa { get; set; }

    }
}
