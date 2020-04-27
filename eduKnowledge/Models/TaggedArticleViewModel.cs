using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eduKnowledge.Models
{
    public class TaggedArticleViewModel
    {
        public int Id { get; set; }
        [Required]
        public ArticleViewModel Article { get; set; }
        public int ArticleId { get; set; }
        [Required]
        public TagViewModel Tag { get; set; }
        public int TagId { get; set; }

        public IEnumerable<SelectListItem> Articles { get; set; }
        public IEnumerable<SelectListItem> Tags { get; set; }

    }
}
