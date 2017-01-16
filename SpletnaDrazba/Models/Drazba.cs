using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpletnaDrazba.Models
{
    public class Drazba
    {
        [Key]
        public int Id { get; set; }

        [RegularExpression(@"(\d{2})/(\d{2})/(\d{4}) (\d{2}):(\d{2})",ErrorMessage = "Datum začetka mora biti napisan v formatu dd/MM/YYYY hh:mm")]
        [Display(Name="Datum in ura začetka")]
        public string DatumOd { get; set; }
        [RegularExpression(@"(\d{2})/(\d{2})/(\d{4}) (\d{2}):(\d{2})", ErrorMessage = "Datum konca mora biti napisan v formatu dd/MM/YYYY hh:mm")]
        [Display(Name = "Datum in ura konca")]
        public string DatumDo { get; set; }
        [Display(Name = "Ime Dražbe")]
        public string Ime { get; set; }
        [Display(Name = "Naziv Predmeta")]
        public string NazivPredmeta { get; set; }
        public string Uporabnik { get; set; }
        public string Opis { get; set; }
        [Display(Name = "Začetna cena (€)")]
        [RegularExpression(@"(\d{1,10})+(.\d{1,2})?", ErrorMessage = "Pri decimalnih vrednostih je potrebna pika in samo dve decimalni mesti")]
        public double ZacetnaCena { get; set; }
        public string Kategorija { get; set; }
        public List<string> Slike { get; set; }
    }
}