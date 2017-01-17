using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpletnaDrazba.Models
{
    public class Ponudba
    {
        [Key]
        public int Id { get; set; }
        public decimal Znesek { get; set; }
        public virtual Drazba Drazba { get; set; }
        [Display(Name="Datum Oddaje")]
        public DateTime DatumOddaje { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}