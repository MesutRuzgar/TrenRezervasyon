using Entity.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete
{
    public class YerlesimAyrinti : IEntity
    {
        [Key]
        public int YerlesimAyrintiID { get; set; }
        public int RezervasyonIstegiID { get; set; }
        public string? VagonAdi { get; set; }
        public int KisiSayisi { get; set; }
    }
}
