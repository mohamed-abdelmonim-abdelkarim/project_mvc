using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task1.Models
{
    public class student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50), MinLength(6)]
        public string? Name { get; set; }
        [RegularExpression(@"[a-zA-Z0-9_]+@[a-zA-Z]+.[a-zA-Z]{2,4}")]
        [Required]
        public string? email { get; set; }
        [Required]
        public string? address { get; set; }
        //[ForeignKey("departments")]
        public int dept_id { get; set; }
        public virtual List<department>? departments { get; set; }
    }
}
