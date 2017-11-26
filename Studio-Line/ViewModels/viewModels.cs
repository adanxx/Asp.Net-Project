using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Studio_Line.Models;

namespace Studio_Line.ViewModels
{
    public class viewModels
    {
        public Magasin magasin { get; set; }
        public List<Customers> Customers { get; set; }
    }
}