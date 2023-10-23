using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDusingEntityFramework.Models
{
    [Table("Student")] //map class with table in DB
    public class Student
    {
        [Key]//this is PK col in DB

        public int Id{ get; set; }
        [Required]

        public string? Name { get; set; }
        [Required]

        public int Percentage { get; set; }
        

    }
}
