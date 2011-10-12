using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InoSoft.TeamStudio.Core.Entities;

using InoSoft.TeamStudio.Core.Services;

namespace InoSoft.TeamStudio.Controllers
{ 
    public class UserController : Controller
    {
		private UsersService _userService = new UsersService();

        //
        // GET: /User/

        public ViewResult Index()
        {
            return View(_userService.GetAllUsers());
        }

        //
        // GET: /User/Details/5

        public ViewResult Details(int id)
		{
			User user = _userService.GetUser(id);
            return View(user);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _userService.CreateUser(user);
                return RedirectToAction("Index");  
            }

            return View(user);
        }
        
        //
        // GET: /User/Edit/5
 
        public ActionResult Edit(int id)
		{
			User user = _userService.GetUser(id);
            return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
				//db.Users.Attach(user);
				//db.ObjectStateManager.ChangeObjectState(user, EntityState.Modified);
				//db.SaveChanges();
                _userService.EditUser(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        //
        // GET: /User/Delete/5
 
        public ActionResult Delete(int id)
        {
			User user = _userService.GetUser(id);
            return View(user);
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
			//User user = db.Users.Single(u => u.UserId == id);
			//db.Users.DeleteObject(user);
			//db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //db.Dispose();
            base.Dispose(disposing);
        }
    }
}