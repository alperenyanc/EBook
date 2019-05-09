using EBook.Model.Option;
using EBook.UI.Areas.Author.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBook.UI.Areas.Author.Models.VM
{
    public class UpdateArticleVM
    {
        public UpdateArticleVM()
        {
            Categories = new List<Category>();
            SubCategories = new List<SubCategory>();
            Article = new ArticleDTO();
        }

        public List<Category> Categories { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        public ArticleDTO Article { get; set; }
    }
}