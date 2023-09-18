using Entity.Abstract;

namespace Entity.Concrete
{
    public class Vagon : IEntity
    {
        public int VagonID { get; set; }
        public int TrenID { get; set; }
        public string? Ad { get; set; }
        public int Kapasite { get; set; }
        public int DoluKoltukAdet { get; set; }
        public Tren? Tren { get; set; }
    }
}
