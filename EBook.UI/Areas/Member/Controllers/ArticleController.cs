using EBook.Service.Option;
using EBook.UI.Areas.Member.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBook.UI.Areas.Member.Controllers
{
    public class ArticleController : Controller
    {
        ArticleService _articleService;
        CategoryService _categoryService;
        AppUserService _appUserService;
        CommentService _commentService;
        LikeService _likeService;

        public ArticleController()
        {
            _articleService = new ArticleService();
            _categoryService = new CategoryService();
            _appUserService = new AppUserService();
            _commentService = new CommentService();
            _likeService = new LikeService();
        }
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult Show(Guid id)
        {
            // vm içine verileri gönderelim..
            ArticleDetailVM model =new ArticleDetailVM();
            model.AppUser = _appUserService.GetById(model.Article.AppUser.ID);// tekil
            model.Article = _articleService.GetById(id);// tekil
            model.Comments = _commentService.GetDefault(x => x.ArticleID == id && (x.Status == Core.Enum.Status.Active || x.Status == Core.Enum.Status.Updated));
            model.likes = _likeService.GetDefault(x => x.ArticleID == id && (x.Status == Core.Enum.Status.Active || x.Status == Core.Enum.Status.Updated));
            model.LikeCount = _likeService.GetDefault(x => x.ArticleID == id && (x.Status == Core.Enum.Status.Active || x.Status == Core.Enum.Status.Updated)).Count;
            model.CommentCount = _commentService.GetDefault(x => x.ArticleID == id && (x.Status == Core.Enum.Status.Active || x.Status == Core.Enum.Status.Updated)).Count;

            return View(model);

        }
    }
}