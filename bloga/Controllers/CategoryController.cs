using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bloga.Models.Entity;
namespace bloga.Controllers
{
    public class CategoryController : Controller
    {
        blogaDBEntities bdg = new blogaDBEntities();
        // GET: Category
        public ActionResult Index(int id)
        {
            return View(id);
        }
        public PartialViewResult CategoryWidget()
        {
            return PartialView(bdg.categories.ToList());
        }
        public ActionResult ArticleList(int id)
        {
            var data = bdg.articles.Where(x => x.CATEGORYID == id).ToList();
            return View("_ArticleList", data);
        }

    }
}