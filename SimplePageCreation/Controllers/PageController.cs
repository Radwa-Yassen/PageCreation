using BLL.Models;
using DAL;
using SimplePageCreation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimplePageCreation.Controllers
{
    public class PageController : Controller
    {
        HandleData dataManger = new HandleData();

        // GET: Page
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Page(Guid pageId)
        {
            var page = new Page("p1", "dec", "", "Windows.2000");//dataManger.GetPage(pageId);
            PageViewModel pageView = new PageViewModel();

            pageView.Id = page.Id;
            pageView.Title = page.Title;
            pageView.Content = page.Content;
            pageView.Description = page.Description;
            pageView.Password = page.Password;

            return View(pageView);
        }

        [HttpPost]
        public ActionResult EditPage(PageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var page = dataManger.GetPage(model.Id);

                page.Title = model.Title;
                page.Description = model.Description;
                page.Content = model.Content;
                page.Password = model.Password;

                dataManger.UpdatePage(page);

                dataManger.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}