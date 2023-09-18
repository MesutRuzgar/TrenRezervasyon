using Entity.Abstract;

namespace Entity.Concrete
{
    public class RezervasyonSonucu : IEntity
    {
        public int RezervasyonSonucuID { get; set; }
        public int RezervasyonIstegiID { get; set; }
        public bool RezervasyonYapilabilir { get; set; }
        public List<YerlesimAyrinti>? YerlesimAyrinti { get; set; }
    }
}
