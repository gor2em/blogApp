using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bloga.App_Classes;
using bloga.Models;
using bloga.Models.Entity;

namespace bloga.Controllers
{
    [Authorize]
    public class ArticleController : Controller
    {
        blogaDBEntities bdg = new blogaDBEntities();




        // GET: Article
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        //[Route("Article/Detail/{}")]
        [AllowAnonymous]
        public ActionResult Detail(int id)
        {
            var data = bdg.articles.FirstOrDefault(x => x.ARTICLEID == id);
            return View(data);
        }

        [Authorize(Roles = "Admin,Yazar")]
        public ActionResult AddArticle()
        {
            ViewBag.Categories = bdg.categories.ToList();
            return View();
        }

        [Authorize(Roles = "Admin,Yazar")]
        [HttpPost]
        public ActionResult AddArticle(article art, HttpPostedFileBase IMAGE)
        {
            Image img = Image.FromStream(IMAGE.InputStream);

            Bitmap sIamge = new Bitmap(img, Settings.smallImage);
            Bitmap mImage = new Bitmap(img, Settings.mediumImage);
            Bitmap bImage = new Bitmap(img, Settings.bigImage);

            sIamge.Save(Server.MapPath("/Content/images/article_image/small/" + IMAGE.FileName));
            mImage.Save(Server.MapPath("/Content/images/article_image/medium/" + IMAGE.FileName));
            bImage.Save(Server.MapPath("/Content/images/article_image/big/" + IMAGE.FileName));

            article_image a_image = new article_image();
            a_image.BIG = "/Content/images/article_image/big/" + IMAGE.FileName;
            a_image.MED = "/Content/images/article_image/medium/" + IMAGE.FileName;
            a_image.MINI = "/Content/images/article_image/small/" + IMAGE.FileName;

            bdg.article_image.Add(a_image);
            bdg.SaveChanges();

            art.IMAGEID = a_image.IMAGEID;
            art.ADATE = DateTime.Now;
            art.AVIEW = 0;
            art.ALIKE = 0;
            int writerId = bdg.users.FirstOrDefault(x => x.USERNAME == User.Identity.Name).USERID;
            art.WRITERID = writerId;
            bdg.articles.Add(art);
            bdg.SaveChanges();
            return RedirectToAction("Index", "Home");

        }

        [AllowAnonymous]
        public string Like(int id)
        {
            article art = bdg.articles.FirstOrDefault(x => x.ARTICLEID == id);
            art.ALIKE++;
            bdg.SaveChanges();
            return art.ALIKE.ToString();
        }


    }
}