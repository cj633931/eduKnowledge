using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eduKnowledge.Models
{
    public class TagViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
