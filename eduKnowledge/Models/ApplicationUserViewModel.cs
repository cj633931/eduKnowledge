using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eduKnowledge.Models
{
    public class ApplicationUserViewModel
    {
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime DateJoined { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
