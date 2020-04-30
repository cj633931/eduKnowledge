using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eduKnowledge.Models
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public ApplicationUserViewModel Author { get; set; } // If the user is deleted, refer to the author being an admin or something
        public string AuthorId { get; set; }
        [Required]
        [Display(Name = "Date Drafted")]
        public DateTime DateDrafted { get; set; }
        [Display(Name = "Date Published")]
        public DateTime? DatePublished { get; set; }
        [Required]
        [Display(Name = "Last Edited")]
        public DateTime LastEdited { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
