using Entity.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete
{
    public class RezervasyonIstegi : IEntity
    {
        [Key]
        public int RezervasyonIstegiID { get; set; }
        public int TrenID { get; set; }
        public Tren? Tren { get; set; }
        public int RezervasyonYapilacakKisiSayisi { get; set; }
        public bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }
    }
}
