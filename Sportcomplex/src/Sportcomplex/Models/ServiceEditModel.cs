using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sportcomplex.Models
{
    public class ServiceEditModel : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }// Описание услгуи
        public string ServiceImgURL { get; set; } // Ссылка на картинку 
        public IFormFile Image { get; set; }
        public double Price { get; set; }  //удалю потом

    }
}
