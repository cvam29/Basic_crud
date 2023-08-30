using System.ComponentModel.DataAnnotations;

namespace Basic_crud.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } =string.Empty;
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Phone { get; set; }

    }
}
