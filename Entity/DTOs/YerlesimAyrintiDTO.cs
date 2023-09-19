using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class YerlesimAyrintiDTO :IDto
    {
        public string? VagonAdi { get; set; }
        public int KisiSayisi { get; set; }
    }
}
