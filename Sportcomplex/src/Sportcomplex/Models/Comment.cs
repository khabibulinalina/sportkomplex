using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sportcomplex.Models
{
    public class Comment: BaseEntity
    {

        public ApplicationUser AppUser { get; set; }

        public string UserId { get; set; }

    public string Email { get; set; }// в данный момент не используется

        [Required]
        public string Title { get; set; }

        [Required]
        public string Message { get; set; }

    }
}
