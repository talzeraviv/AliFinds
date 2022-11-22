using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class AliFind
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        [Column(TypeName="money")]
        public decimal Price { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string Link { get; set; }
    }
}