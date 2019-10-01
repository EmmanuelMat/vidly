using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id   { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; } 

        [Display(Name = "Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }  

        [Display(Name = "Number In Stuck")]      
        [Required]
        [Range(1,20)]    
        public int NumberOnStuck { get; set; }

        public int GenreId { get; set; }
        [Required]
        public Genre Genre { get; set; }

    }
}