using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task1.Models
{
    public class department
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? dept_Id { get; set; }
        [Required]
        [MaxLength(50),MinLength(6)]
        public string? dept_Name { set; get; }

        public virtual student? Students { get; set; }
    }
}
