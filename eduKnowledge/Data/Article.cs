using eduKnowledge.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eduKnowledge.Data
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [ForeignKey("AuthorId")]
        public ApplicationUser Author { get; set; } // If the user is deleted, refer to the author being an admin or something
        public string AuthorId { get; set; }
        [Required]
        public DateTime DateDrafted { get; set; }
        public DateTime? DatePublished { get; set; }
        [Required]
        public DateTime LastEdited { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
