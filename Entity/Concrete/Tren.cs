using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Tren :IEntity
    {
        [Key]
        public int TrenID { get; set; }
        public string? Ad { get; set; }
        public List<Vagon>? Vagonlar { get; set; }
    }
}
