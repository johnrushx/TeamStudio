using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InoSoft.TeamStudio.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Message = "Welcome to TeamStudio";

			return View();
		}

		public ActionResult About()
		{
			return View();
		}
	}
}
