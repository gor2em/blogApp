using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bloga.Models.Entity;
namespace bloga.Controllers
{
    public class HomeController : Controller
    {

        blogaDBEntities bdb = new blogaDBEntities();
        
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult ArticleList()
        {
            var data = bdb.articles.OrderByDescending(x=>x.ARTICLEID).ToList();
            return View("_ArticleList", data);
        }

        public  PartialViewResult PopularArticle()
        {
            var model = bdb.articles.OrderByDescending(x => x.ADATE).Take(5).ToList();
            return PartialView(model);
        }

    }
}