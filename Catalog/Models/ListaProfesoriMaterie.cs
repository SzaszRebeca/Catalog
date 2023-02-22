namespace Catalog.Models
{
    public class ListaProfesoriMaterie
    {
        public int ID { get; set; }
        public int? MaterieID { get; set; }
        public Materie? Materie { get; set; }
        public int? ProfesorID { get; set; }
        public Profesor? Profesor { get; set; }
    }
}
