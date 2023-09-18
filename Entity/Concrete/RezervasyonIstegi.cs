using Entity.Abstract;

namespace Entity.Concrete
{
    public class RezervasyonIstegi : IEntity
    {
        public int RezervasyonIstegiID { get; set; }
        public int TrenID { get; set; }
        public Tren? Tren { get; set; }
        public int RezervasyonYapilacakKisiSayisi { get; set; }
        public bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }
    }
}
