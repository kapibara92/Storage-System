using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;
using System.Web.Services;
using WebStorageApplication.Models;

namespace WebStorageApplication.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// lista produktów
        /// </summary>
        private List<ProductList> Products { get; set; }
        /// <summary>
        /// funkcja zwracająca listę wszystkich metod wysyłki towaru
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ActionResult Autocomplete(string value)
        {
          var data=DatabaseOperation.showMatchDelivery();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// filtracja listy produktów
        /// </summary>
        /// <param name="filterName">filtr po nazwie produktu</param>
        /// <param name="filterCode">filtr po kodzie produktu</param>
        /// <returns></returns>
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
        public ActionResult CreateOrder(string nameProduct, long? codeProduct)
        {
            ViewBag.CodeProduct = codeProduct;
            if (nameProduct==null && codeProduct==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderList order = new OrderList(nameProduct);
            return View(order);
        }

        /// <summary>
        /// zwraca widok do dodawania zamówienia
        /// </summary>
        /// <param name="Order">szczegóły zamówienia</param>
        /// <param name="codeProduct">kod produktu</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult CreateOrder([Bind(Include = "orderDate,address,delivery,nameProduct,quantity")]OrderList Order, [Bind(Include ="ViewBag.CodeProduct")]long? codeProduct)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DatabaseOperation.realiseOrder(Order.nameProduct, Order.delivery, Order.address,Order.quantity, codeProduct);
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(Order);
        }

    }
}