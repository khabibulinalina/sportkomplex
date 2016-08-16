using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sportcomplex.Models
{
    public class Contact : BaseEntity
    {
        [Required]
        public string address { get; set; }

        [Required]
        public double x { get; set; }

        [Required]
        public double y { get; set; }
    }
}