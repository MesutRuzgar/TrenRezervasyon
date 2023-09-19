using Entity.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete
{
    public class RezervasyonSonucu : IEntity
    {
        [Key]
        public int RezervasyonSonucuID { get; set; }
        public int RezervasyonIstegiID { get; set; }
        public bool RezervasyonYapilabilir { get; set; }
        public List<YerlesimAyrinti>? YerlesimAyrinti { get; set; }
    }
}
