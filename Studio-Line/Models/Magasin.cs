using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Studio_Line.Models
{
    public class Magasin
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public String Name { get; set; }

        public Genre Genre { get; set; }

        public Byte GenreId { get; set; }

        [Display(Name =" Date of Relase")]
        public DateTime RealeaseDate { get; set; }

        [Display(Name = " Date Add to the List")]
        public DateTime DataAdd { get; set; }

        [Display(Name = "Number in Stock")]
        public byte InStock { get; set; }

    }
}