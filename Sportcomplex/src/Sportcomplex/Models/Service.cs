using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sportcomplex.Models
{
    public class Service : BaseEntity
    {   
        public string Title { get; set; }
        public string Description { get; set; }// Описание услгуи
        public string ServiceImgURL { get; set; } // Ссылка на картинку 
    }
}