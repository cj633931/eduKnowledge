using eduKnowledge.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eduKnowledge.Data
{
    public class TaggedArticle
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ArticleId")]
        public Article Article { get; set; }
        public int ArticleId { get; set; }
        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
        public int TagId { get; set; }
    }
}
