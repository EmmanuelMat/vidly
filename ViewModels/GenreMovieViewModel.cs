using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;
namespace Vidly.ViewModels
{
    public class GenreMovieViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }  
        

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
         
        public string title{
            get{
                return Id != 0 ? "Edit" : "New Movie";
            }
        }
        public GenreMovieViewModel ()
        {
            Id = 0;
        }

        public GenreMovieViewModel (Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            DateAdded = movie.DateAdded;
            NumberOnStuck = movie.NumberOnStuck;

        }
        

    }
    
}