using System.ComponentModel.DataAnnotations;

namespace Mission06_Child.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
