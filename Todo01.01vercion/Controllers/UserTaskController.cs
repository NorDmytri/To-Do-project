    using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Todo01._01vercion.Models;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Todo01._01vercion.Filters;

namespace Todo01._01vercion.Controllers
{
    [Culture]
    [Authorize]
    public class UserTaskController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserTask
        public ActionResult Index()
        {
            // передача через сессию

            ViewBag.UserId = Session["UserId"] as string;

            // передача через куки
            ViewBag.CookUserId = HttpContext.Request.Cookies["CookUserId"].Value;

            string UserId = Session["UserId"] as string;
            if (UserId == null)
                UserId = HttpContext.Request.Cookies["CookUserId"].Value;
            if (UserId == null)
            {
                return RedirectToAction("NeedLogin");
            }
            

            //List<UserTask> AllTask = await db.UserTasks.ToListAsync();
           // var userTask = AllTask.Where(t => t.UserId == UserId);
            return View(db.UserTasks.Where(t => t.UserId == UserId));
        }

        [HttpPost]
        public async Task<ActionResult> Index(string calendar)
        {
           
            string UserId = Session["UserId"] as string;
            if (UserId == null)
                UserId = HttpContext.Request.Cookies["CookUserId"].Value;
            if (UserId == null)
            {
                return RedirectToAction("NeedLogin");
            }
            DateTime dateSer;
            DateTime.TryParse(calendar, out dateSer);
   
            List<UserTask> AllTask = await db.UserTasks.ToListAsync();
            var userTask = AllTask.Where(t => t.UserId == UserId && t.TaskDate.Date == dateSer.Date );
            return View(userTask);
        }


  


        public ActionResult NeedLogin()
        {
            return View();
        }

        // GET: UserTask/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTask userTask = db.UserTasks.Find(id);
            if (userTask == null)
            {
                return HttpNotFound();
            }
            return View(userTask);
        }

        // GET: UserTask/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserTask/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserTaskId,TaskDate,TaskTime,TaskTitle,UseMap,MapPoin,Taskdescription,Status")] UserTask userTask)
        {
            
            try
            {
                if (userTask.UseMap == true)
                {
                    Regex reg = new Regex("^[-0-9]{1}([0-9]{0,2})?([.]{0,1})?([0-9]{0,15})?$");

                    if (!reg.IsMatch(userTask.MapPoin.Maplng))
                    {
                        throw new Exception(Resources.Resource.MaplngErr);
                    }
                    if (!reg.IsMatch(userTask.MapPoin.MapLat))
                    {
                        throw new Exception(Resources.Resource.MapLatErr);
                    }
                }
                if(userTask.TaskDate.Year <1900 || userTask.TaskDate.Year > 3000)
                {
                    throw new Exception(Resources.Resource.TaskDateErr);
                }
               
            }
            catch(Exception e)
            {
                ModelState.AddModelError("",e.Message);
            }

            if (ModelState.IsValid)
            {
                
                
                if (userTask.UseMap == false)
                {                    
                    userTask.MapPoin = new PointModel() { MapLat = String.Empty, Maplng = String.Empty, MapTitle = String.Empty };
                }
                
                string UsId = Session["UserId"] as string;
                if (UsId == null)
                    UsId = HttpContext.Request.Cookies["CookUserId"].Value;
                if (UsId == null)
                    RedirectToAction("NeedLogin");


                userTask.UserId = UsId;

                db.UserTasks.Add(userTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userTask);
        }

        // GET: UserTask/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTask userTask = db.UserTasks.Find(id);
            if (userTask == null)
            {
                return HttpNotFound();
            }
            return View(userTask);
        }

        // POST: UserTask/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserTaskId,TaskDate,TaskTime,TaskTitle,UseMap,MapPoin,Taskdescription,Status")] UserTask userTask)
        {
            try
            {
                if (userTask.UseMap == true)
                {
                    Regex reg = new Regex("^[-0-9]{1}([0-9]{0,2})?([.]{0,1})?([0-9]{0,15})?$");

                    if (!reg.IsMatch(userTask.MapPoin.Maplng))
                    {
                        throw new Exception(Resources.Resource.MaplngErr);
                    }
                    if (!reg.IsMatch(userTask.MapPoin.MapLat))
                    {
                        throw new Exception(Resources.Resource.MapLatErr);
                    }
                }
                if (userTask.TaskDate.Year < 1900 || userTask.TaskDate.Year > 3000)
                {
                    throw new Exception(Resources.Resource.TaskDateErr);
                }

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            if (ModelState.IsValid)
            {
                if (userTask.UseMap == false)
                {
                    userTask.MapPoin = new PointModel() { MapLat = String.Empty, Maplng = String.Empty, MapTitle = String.Empty };
                }

                string UsId = Session["UserId"] as string;
                if (UsId == null)
                    UsId = HttpContext.Request.Cookies["CookUserId"].Value;
                if (UsId == null)
                    RedirectToAction("NeedLogin");


                userTask.UserId = UsId;

                db.Entry(userTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userTask);
        }

        // GET: UserTask/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTask userTask = db.UserTasks.Find(id);
            if (userTask == null)
            {
                return HttpNotFound();
            }
            return View(userTask);
        }

        // POST: UserTask/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserTask userTask = db.UserTasks.Find(id);
            db.UserTasks.Remove(userTask);
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
