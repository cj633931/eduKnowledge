using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eduKnowledge.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        [Required]
        public ArticleViewModel Article { get; set; }
        public int ArticleId { get; set; }
        [Required]
        public ApplicationUserViewModel Author { get; set; }
        public string AuthorId { get; set; }

        public IEnumerable<SelectListItem> Articles { get; set; }
        public IEnumerable<SelectListItem> Authors { get; set; }
    }
}
