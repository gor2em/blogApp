using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bloga.Models.Entity;
namespace bloga.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        blogaDBEntities bdg = new blogaDBEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult wApproved()
        {
            var data = bdg.users.Where(x => x.WRITER == true && x.APPROVED == false).ToList();
            return View(data);
        }

        public ActionResult wRole(int id)
        {
            user u = bdg.users.FirstOrDefault(x => x.USERID == id);
            u.APPROVED = true;

            user_role ur = new user_role();
            ur = bdg.user_role.FirstOrDefault(x => x.USERID == id);
            bdg.user_role.Remove(ur);
            bdg.SaveChanges();

            role writer = bdg.roles.FirstOrDefault(x => x.ROLENAME == "Yazar");

            ur.ROLEID = writer.ROLEID;
            ur.USERID = id;

            bdg.user_role.Add(ur);
            bdg.SaveChanges();

            return RedirectToAction("wApproved");
        }
    }
}