using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApplication1.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public byte[]? AvatarImage { get; set; }
        //public string MimeType { get; set; } = string.Empty;

        //[NotMapped]
        //public IFormFile Avatar { get; set; }


    }
}
