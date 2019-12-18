using Microsoft.AspNet.Identity;
using Send.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Send.Controllers
{
    public class MessageController : Controller
    {
        public ActionResult ShowUsers()
        {
            List<ApplicationUser> users = null;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                users = db.Users.ToList();
            }
            return View(users);
        }

        public ActionResult Send(string id)
        {
            ViewBag.IdGetter = id;
            return View();
        }

        [HttpPost]
        public ActionResult SendMessage(MessageModel message)
        {
            var idSend = User.Identity.GetUserId();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
               db.Messages.Add(new Message { MessageText = message.Mess, IdGetter = message.IdGetter, IdSender = idSend });
                db.SaveChanges();
            }
            return RedirectToAction("Index","Manage");
        }

        public ActionResult ShowMessage()
        {
            var idGet = User.Identity.GetUserId();
            List<Message> allMess = null;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                allMess = db.Messages.Where(x=>x.IdGetter == idGet).ToList();

            }
            return View(allMess);
        }
    }
}