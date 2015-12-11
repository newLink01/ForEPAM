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






        public ActionResult ShowSomeThings()
        {
            
            ViewBag.SaleCollection = saleRep.GetAll();
            ViewBag.TotalSaleRecords = saleRep.GetAll().Count();
            return View();
        }

    }
}
