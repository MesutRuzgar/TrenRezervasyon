using Entity.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class TrenDTO :IDto
    {
        public string? Ad { get; set; }
        public List<VagonDTO>? Vagonlar { get; set; }

    }
}
