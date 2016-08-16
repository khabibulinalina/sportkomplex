using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sportcomplex.Models
{
    public class EditImage
    {
        public long Id { get; set; }
        public IFormFile Image { get; set; }
    }
}
