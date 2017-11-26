using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Studio_Line.Models;

namespace Studio_Line.ViewModels
{
    public class NewCustomerViewModels
    {
        public IEnumerable<MembershipType> Memebershipstypeslist { get; set; }
        public Customers Customer { get; set; }
    }
}