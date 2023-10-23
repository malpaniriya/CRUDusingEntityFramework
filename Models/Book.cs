using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDusingEntityFramework.Models
{
    //this class also called as Entity class/BO(business object) POCO(Plain old CLR Object) class
    [Table("Book")] //map class with table in DB
    public class Book
    {
        [Key]//this is PK col in DB
        
        public int Id { get; set; }
        [Required]

        public string? Name { get; set; }
        [Required]

        public string? Author { get; set; }
        [Required]    

        public int Price { get; set; }
    }
}
