using System.ComponentModel.DataAnnotations;

namespace STGApplication.Models
{
    public class Animal
    {
        [Key]
        [Required]
        public int AnimalId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Breed { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required]
        [StringLength(10)]
        public string Sex { get; set; }
        [Required]
        public Decimal Price { get; set; }
        [Required]
        [StringLength(10)]
        public string Status { get; set; }
    }
}
