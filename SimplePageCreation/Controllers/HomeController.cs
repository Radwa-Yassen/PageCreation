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
    public class HomeController : Controller
    {
        HandleData dataManger = new HandleData();

        public ActionResult Index()
        {
            var pages = new List<Page>()
                { new Page("p1","dec","","Windows.2000"),new Page("p2","dec","","Windows.2000"),new Page("p3","dec","","Windows.2000")};//dataManger.GetPages();

            List<PageListViewModel> pagesViewModelList = new List<PageListViewModel>();

            foreach (var page in pages)
            {
                PageListViewModel pageView = new PageListViewModel();

                pageView.Id = page.Id;
                pageView.Title = page.Title;

                pagesViewModelList.Add(pageView);
            }
            return View(pagesViewModelList);
        }

        public ActionResult AddPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPage(AddPageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var page = new Page(model.Title, model.Description, model.Content, model.Password);

                dataManger.AddPage(page);
                dataManger.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

    }
}