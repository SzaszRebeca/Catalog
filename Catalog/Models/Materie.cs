namespace Catalog.Models
{
    public class Materie
    {
        public int ID { get; set; }
        public string NumeMaterie { get; set; } = string.Empty;
        public ICollection<Student>? Studenti { get; set; }
    }
}
