using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sportcomplex.Models
{
    public class Main : BaseEntity
    {
        [Required]
        public string MainImageURL { get; set; } // Строка, хранящая ссылку на изображение
    }
}