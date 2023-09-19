using Entity.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete
{
    public class Vagon : IEntity
    {
        [Key]
        public int VagonID { get; set; }
        public int TrenID { get; set; }
        public string? Ad { get; set; }
        public int Kapasite { get; set; }
        public int DoluKoltukAdet { get; set; }
        public Tren? Tren { get; set; }
    }
}
