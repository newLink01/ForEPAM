using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FifthTask.DAL.Repositories;
using FifthTask.Models;
namespace FifthTask.Controllers
{
    public class TradeController : Controller
    {
        //
        // GET: /Trade/
       // [Authorize]
        private SaleRepository saleRep;
        private ManagerRepository managerRep;
        private ProductRepository productRep;
        IEnumerable<FormattedSale> formattedSales;
        public TradeController() {
            this.saleRep = new SaleRepository();
            this.managerRep = new ManagerRepository();
            this.productRep = new ProductRepository();
            formattedSales = new List<FormattedSale>();
        }

       /* private void FormatSalesIn(ref IEnumerable<FormattedSale> formattedCollection)
        {  //set values instead Id

            foreach (var sale in saleRep.GetAll())
            {
                foreach (var manager in managerRep.GetAll())
                {
                    if(manager.ManagerId == sale.Manager)
                }
            }

        }*/


        [HttpGet]
        public ActionResult Workplace()
        {
            
            ViewBag.SaleCollection = saleRep.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Workplace(string filter) {

            ViewBag.SaleCollection = saleRep.GetAll();
           
                ViewBag.filter = filter;
            
            
            return View();
        }

        public ActionResult EditRecords() {

            return View();
        }



        public ActionResult ShowManagers() {
            ViewBag.ManagerCollection = managerRep.GetAll();
            return View();
        }
        public ActionResult ShowProducts() {

            ViewBag.ProductCollection = productRep.GetAll();

            return View();
        }
        public ActionResult ShowSales() {


            ViewBag.SaleCollection = saleRep.GetAll();
            return View();
}


    }
}
