using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Child.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Sorry, category is required")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Sorry, title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Sorry, year is required")]
        [Range(1888, 9999, ErrorMessage = "Year must be between 1888 and 9999")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Sorry, director is required")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Sorry, rating is required")]
        public string Rating { get; set; }

        [Required(ErrorMessage = "Sorry, edited field is required")]
        public bool Edited { get; set; }

        public string? LentTo { get; set; }

        [Required(ErrorMessage = "Sorry, CopiedToPlex field is required")]
        public bool CopiedToPlex { get; set; }

        [StringLength(25, ErrorMessage = "Sorry, notes cannot exceed 25 characters")]
        public string? Notes { get; set; }

        [ValidateNever]
        public Category Category { get; set; }
    }
}
