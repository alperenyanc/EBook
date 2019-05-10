using EBook.Model.Option;
using EBook.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBook.UI.Areas.Member.Controllers
{
    public class CommentController : Controller
    {
        CommentService _commentService;
        AppUserService _appUserService;
        LikeService _likeservice;
        ArticleService _articleService;
        public CommentController()
        {
            _commentService = new CommentService();
            _appUserService = new AppUserService();
            _likeservice = new LikeService();
            _articleService = new ArticleService();
        }

        public JsonResult AddComment(string userComment,Guid id)
        {
            Comment comment = new Comment();

            comment.Content = userComment;
            comment.AppUserID = _appUserService.FindByUserName(HttpContext.User.Identity.Name).ID;
            comment.ArticleID = id;

            bool IsAdded = false;
            try
            {
                _commentService.Add(comment);
                IsAdded = true;
            }
            catch (Exception exp)
            {

                IsAdded = false;
            }
            return Json(IsAdded, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetArticleCommend(string id)
        {
            Guid articleID = new Guid(id);

            Comment comment = _commentService.GetDefault(x => x.ArticleID == articleID && x.Status == Core.Enum.Status.Active).LastOrDefault();
            return Json(new
            {
                AppUserImagePath = comment.AppUser.UserImage,
                FirstName = comment.AppUser.FirstName,
                LastName = comment.AppUser.LastName,
                CreatedDate = comment.AppUser.CreatedDate.ToString(),
                Content = comment.Content,
                CommentCount = _commentService.GetDefault(x => x.ArticleID == articleID && (x.Status == Core.Enum.Status.Active || x.Status == Core.Enum.Status.Updated)).Count(),
                LikeCount = _likeservice.GetDefault(x => x.ArticleID == articleID && (x.Status == Core.Enum.Status.Active || x.Status == Core.Enum.Status.Updated)).Count(),
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteComment(Guid id)
        {
            Guid userID = _appUserService.FindByUserName(HttpContext.User.Identity.Name).ID;
            bool IsDelete = false;

            if (_commentService.Any(x=>x.AppUserID==userID))
            {
                IsDelete = true;
                _commentService.Remove(id);
                return Json(IsDelete, JsonRequestBehavior.AllowGet);

            }
            else
            {
                IsDelete = false;
                return Json(IsDelete, JsonRequestBehavior.AllowGet);
            }
        }
    }
}