using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using bloga.Models.Entity;

namespace bloga.Controllers
{
    public class UserController : Controller
    {
        blogaDBEntities bdg = new blogaDBEntities();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(user u)
        {

            string gelenKullanici = validateUser(u.USERNAME, u.PASSWORD);
            if (!string.IsNullOrEmpty(gelenKullanici))//rol null veya boş değilse
            {
                int userId = bdg.users.FirstOrDefault(x => x.USERNAME == gelenKullanici).USERID;
                var uS = bdg.users.Find(userId);
                Session["WRITER"] = uS.WRITER;

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, u.USERNAME, DateTime.Now, DateTime.Now.AddMinutes(30)
                    , true, gelenKullanici, FormsAuthentication.FormsCookiePath);

                HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName);
                if (ticket.IsPersistent)
                {
                    ck.Expires = ticket.Expiration;//ticket death time
                }

                Response.Cookies.Add(ck);

                FormsAuthentication.RedirectFromLoginPage(u.USERNAME, true);



                ////Response.Redirect(FormsAuthentication.GetRedirectUrl(u.USERNAME, true));
                //return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login");
        }
        string validateUser(string userName, string pass)
        {

            user u = bdg.users.FirstOrDefault(x => x.USERNAME == userName && x.PASSWORD == pass);
            if (u != null)
                return u.USERNAME;
            else
                return "";

        }
        public ActionResult Exit(string redirectUrl)
        {
            FormsAuthentication.SignOut();
            return Redirect(redirectUrl);
        }

        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(user u)
        {
            var userControl = bdg.users.Any(x=>x.USERNAME==u.USERNAME || x.USEREMAIL==u.USEREMAIL);
            if (userControl)
            {
                ModelState.AddModelError("Error", "Email veya kullanıcı adı alınmış");
                return View();
            }
            else
            {
                u.WRITER = false;
                u.APPROVED = true;
                u.ACTIVE = true;
                u.DATEOFREGISTRATION = DateTime.Now;
                bdg.users.Add(u);
                bdg.SaveChanges();


                role member = bdg.roles.FirstOrDefault(x => x.ROLENAME == "Üye");

                user_role ur = new user_role();
                ur.ROLEID = member.ROLEID;
                ur.USERID = u.USERID;

                bdg.user_role.Add(ur);
                bdg.SaveChanges();
                return RedirectToAction("Login");
            }


            
        }
    }
}