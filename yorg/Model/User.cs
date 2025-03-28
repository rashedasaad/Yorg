using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace yorg.Model
{
    public class User
    {
     
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }


        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }


        public string GoogleId { get; set; } 

        public string ProfilePictureUrl { get; set; }  

        public string AppleId { get; set; }  

        public bool IsEmailVerified { get; set; }

        public string AuthenticationProvider { get; set; }

        public bool IsAdmin { get; set; }

    }
}
