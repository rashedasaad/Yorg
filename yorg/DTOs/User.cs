using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace yorg.DTOs
{
    public class User
    {

        public Guid? Id { get; set; }


        public string Name { get; set; }

        
        public string Role { get; set; }


        public bool IsEmailVerified { get; set; }

        public bool IsAdmin { get; set; }

    }
}
