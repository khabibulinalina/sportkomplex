using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sportcomplex.Models
{
    public class Price: BaseEntity
    {
        [Required]
        [Display(Name = "Name of sport")]
        public string NameOfSport { get; set; }

        [Required]
        [Display(Name = "Time of gym")]
        public string TimeOfGym { get; set; }

        [Display(Name = "One work")]
        public string One_work { get; set; }

        [Display(Name = "For work")]
        public string For_work { get; set; }

        [Display(Name = "Eight work")]
        public string Eight_work { get; set; }

        [Display(Name = "Eleven work")]
        public string Eleven_work { get; set; }

    }
}
   