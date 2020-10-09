using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bloga.Models.Entity;

namespace bloga.Controllers
{
    public class LabelController : Controller
    {
        blogaDBEntities bdg = new blogaDBEntities();
        // GET: Label
        public ActionResult Index(int id)
        {
            return View(id);
        }
        public PartialViewResult LabelWidget()
        {
            return PartialView(bdg.labels.ToList());
        }
        public ActionResult ArticleList(int id)
        {
            var data = bdg.articles.Where(x => x.labels.Any(y => y.LABELID == id)).ToList();
            return View("_ArticleList", data);
        }
    }
}