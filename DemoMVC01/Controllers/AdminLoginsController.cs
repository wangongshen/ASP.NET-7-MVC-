using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoMVC01.Models;

namespace DemoMVC01.Controllers
{
    public class AdminLoginsController : Controller
    {
        private itcastEntities db = new itcastEntities();

        [HttpGet]
        public ActionResult Login()
        {
            Console.WriteLine("123456");
            return View(); 
        }

        //public ActionResult Login(string s)
        //{
        //    //第一种
        //    string userName = Request["AdminName"];
        //    string pwd = Request["Pwd"];

        //    return Content("321:"+userName+"22:"+pwd);
        //}

        //public ActionResult Login(FormCollection collection)
        //{
        //    //第二种
        //    string username = collection["AdminName"];
        //    string pwd = collection["Pwd"];

        //    return Content("321:"+ username + "22:"+pwd);
        //}

        //public ActionResult Login(string AdminName,string Pwd)
        //{
        //    //第三种
        //    return Content("321:"+ AdminName + "22:"+ Pwd);
        //}

 
        public ActionResult Login(AdminLogin admin)
        {
            //第四种
            AdminLogin user = db.AdminLogin.SingleOrDefault<AdminLogin>(n=>n.AdminName==admin.AdminName);
            if (user == null)
            {
                return Content("用户名不存在");
            }
            else {
                if (user.Pwd==admin.Pwd)
                {
                    return RedirectToAction("index",user);
                }
                else
                {
                    Content("密码错误");
                }
            }
            return Content("321:"+ admin.AdminName + "22:" + admin.Pwd);
        }

        // GET: AdminLogins
        public ActionResult Index(AdminLogin admin)
        {
            //将获得的用户名存储到viewBag中
            //ViewBag.UserName = admin.AdminName;
           // ViewData["name"] = admin.AdminName;
            ViewData.Model = admin;
            return View();
        }

        // GET: AdminLogins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogin adminLogin = db.AdminLogin.Find(id);
            if (adminLogin == null)
            {
                return HttpNotFound();
            }
            return View(adminLogin);
        }

        // GET: AdminLogins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminLogins/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AdminName,Pwd")] AdminLogin adminLogin)
        {
            if (ModelState.IsValid)
            {
                db.AdminLogin.Add(adminLogin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adminLogin);
        }

        // GET: AdminLogins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogin adminLogin = db.AdminLogin.Find(id);
            if (adminLogin == null)
            {
                return HttpNotFound();
            }
            return View(adminLogin);
        }

        // POST: AdminLogins/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AdminName,Pwd")] AdminLogin adminLogin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminLogin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminLogin);
        }

        // GET: AdminLogins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogin adminLogin = db.AdminLogin.Find(id);
            if (adminLogin == null)
            {
                return HttpNotFound();
            }
            return View(adminLogin);
        }

        // POST: AdminLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminLogin adminLogin = db.AdminLogin.Find(id);
            db.AdminLogin.Remove(adminLogin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
