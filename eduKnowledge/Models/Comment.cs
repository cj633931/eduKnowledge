using eduKnowledge.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eduKnowledge.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ArticleId")]
        public Article Article { get; set; }
        public int ArticleId { get; set; }
        [ForeignKey("AuthorId")]
        public ApplicationUser Author { get; set; }
        public string AuthorId { get; set; }
    }
}
