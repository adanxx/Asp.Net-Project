using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Studio_Line.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public String Name { get; set; }
        public String SignUpFee { get; set; }
        public byte DurationsInMonth { get; set; }
        public byte DiscountRate { get; set; }


    }
}