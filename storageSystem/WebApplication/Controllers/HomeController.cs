using storageSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private List<ProductList> Products { get; set; }
        //public ActionResult Index()
        //{
        //   Products= DatabaseOperation.showProducts();
        //    return View(Products);
        //}
        // GET: Index
        public ActionResult Index(string filterName, string filterCode)
        { 
            #region inicjowanie pol  ViewBag
            if (filterName != null)
            {
                ViewBag.FilterName = filterName;
            }
            else
            {
                ViewBag.FilterName = "";
            }
            if (filterCode != null)
            {
                ViewBag.FilterCode = filterCode;
            }
            else
            {
                ViewBag.FilterCode = "";
            }
            #endregion
            Products = DatabaseOperation.filterProducts(ViewBag.FilterName, ViewBag.FilterCode);
            return View(Products);
            

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
           

            return View();
        }
    }
}