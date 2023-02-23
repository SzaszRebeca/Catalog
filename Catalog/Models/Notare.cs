using System.ComponentModel.DataAnnotations;

namespace Catalog.Models
{
    public class Notare
    {
        public int ID { get; set; }
        public int? MemberID { get; set; }
        public Member? Member { get; set; }
        public int? StudentID { get; set; }
        public Student? Student { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }
    }
}
