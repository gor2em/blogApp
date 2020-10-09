using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bloga.Models.Entity;

namespace bloga.Controllers
{
    public class WriterController : Controller
    {
        blogaDBEntities bdg = new blogaDBEntities();
        // GET: Writer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult WriterON()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterON(string bio)
        {
            int userId = bdg.users.FirstOrDefault(x => x.USERNAME == User.Identity.Name).USERID;
            var u = bdg.users.Find(userId);
            u.WRITER = true;
            u.APPROVED = false;
            u.BIO = bio;
            Session["WRITER"] = u.WRITER;
            bdg.SaveChanges();

           

            return RedirectToAction("Index", "Home");

        }
    }
}