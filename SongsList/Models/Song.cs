using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SongsList.Models
{
    public class Song
    {
        public int SongId { get; set; }
        
        [Required(ErrorMessage ="Please enter a song name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please enter a year")]
        [Range(1900,2021,ErrorMessage ="Enter a year from 1900 to 2021")]
        public int? Year { get; set; }

        [Required(ErrorMessage ="Please select a Rating")]
        [Range(1,5,ErrorMessage ="Range must from from 1 to 5")]
        public int? Rating { get; set; }

        [Required(ErrorMessage = "Please enter a Genre")]
        public string GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
