using EBook.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBook.UI.Areas.Member.Models.VM
{
    public class ArticleDetailVM
    {
        public ArticleDetailVM()
        {
            AppUsers =new List<AppUser>();
            Comments = new List<Comment>();
            likes = new List<Like>();
            Like = new Like();
            Articles = new List<Article>();
            Article = new Article();
            AppUser = new AppUser();
            Comment = new Comment();
        }

        public int LikeCount { get; set; }
        public int CommentCount { get; set; }

        public List<Comment> Comments { get; set; }
        public List<Like> likes { get; set; }
        public List<Article> Articles { get; set; }
        public List<AppUser> AppUsers { get; set; }
        public Like Like { get; set; }
        public Comment Comment { get; set; }
        public Article Article { get; set; }
        public AppUser AppUser { get; set; }
    }
}