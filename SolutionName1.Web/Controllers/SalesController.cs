using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SolutionName1.DataLayer;
using SolutionName1.Model;
using SolutionName1.Web.ViewModels;

namespace SolutionName1.Web.Controllers
{
    public class SalesController : Controller
    {
        private SalesContext _salesContext;

        public SalesController()
        {
            _salesContext = new SalesContext();
        }

        // GET: Sales
        public ActionResult Index()
        {
            return View(_salesContext.SalesOrders.ToList());
        }

        // GET: Sales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = _salesContext.SalesOrders.Find(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }

            SalesOrderViewModel salesOrderViewModel = new SalesOrderViewModel();
            salesOrderViewModel.SalesOrderId = salesOrder.SalesOrderId;
            salesOrderViewModel.CustomerName = salesOrder.CustomerName;
            salesOrderViewModel.PONumber = salesOrder.PONumber;
            salesOrderViewModel.MessageToClient = "I originated from the viewModel, rather then the model";

            return View(salesOrderViewModel);//zmieniam żeby brał nie z modelu date return View(salesOrder) tylko z nowego modelu
        }

        // GET: Sales/Create
        public ActionResult Create()
        {
            SalesOrderViewModel salesOrderViewModel = new SalesOrderViewModel();
            //var id = _salesContext.SalesOrders.Last().SalesOrderId;

            //salesOrderViewModel.CustomerName = "";
            return View(salesOrderViewModel);
        }

        // GET: Sales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = _salesContext.SalesOrders.Find(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }
            return View(salesOrder);
        }

        // GET: Sales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = _salesContext.SalesOrders.Find(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }
            return View(salesOrder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _salesContext.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult Save(SalesOrderViewModel salesOrderViewModel)
        {
            SalesOrder salesOrder = new SalesOrder();
            salesOrder.CustomerName = salesOrderViewModel.CustomerName;
            salesOrder.PONumber = salesOrderViewModel.PONumber;

            try
            {
                _salesContext.SalesOrders.Add(salesOrder);
                _salesContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            salesOrderViewModel.MessageToClient = string.Format("{0}’s sales order has been added to the database.", salesOrder.CustomerName);

            return Json(new { salesOrderViewModel });
        }
    }
}
