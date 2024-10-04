using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stdDetails.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }

        [Column("StudentName", TypeName = "varchar(100)")]
		[StringLength(15, MinimumLength = 3, ErrorMessage = "Name must be with in 3 to 15 characters.")]
		[Display(Name = "Student Name")]
		[Required]
        public string Name { get; set; }

        [Column("StudentAge", TypeName = "varchar(100)")]
		[Range(8, 80, ErrorMessage = "Your age must be bewteen 8 to 80.")]
		[Required]
        public int? Age { get; set; }

        [Column("StudentStandard", TypeName = "varchar(100)")]
		[Range(1, 18, ErrorMessage = "Your age must be bewteen 1 to 18.")]
		[Required]
        public int? Standards { get; set; }
    }
}
