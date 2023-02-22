namespace Catalog.Models
{
    public class Nota
    {
        public int ID { get; set; }
        public decimal Valoare { get; set; }
        public int? MaterieID { get; set; }
        public Materie? Materie { get; set; }
        public int? StudentID { get; set; }
        public Student? Student { get; set; }

    }
}
