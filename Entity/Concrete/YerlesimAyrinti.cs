using Entity.Abstract;

namespace Entity.Concrete
{
    public class YerlesimAyrinti : IEntity
    {
        public int YerlesimAyrintiID { get; set; }
        public int RezervasyonIstegiID { get; set; }
        public string? VagonAdi { get; set; }
        public int KisiSayisi { get; set; }
    }
}
