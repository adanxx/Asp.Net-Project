using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Studio_Line.Models;

namespace Studio_Line.ViewModels
{
    public class viewGenreModel
    {
        public IEnumerable<Genre> GenreList { get; set; }
        public Magasin magasin { get; set; }
    }
}