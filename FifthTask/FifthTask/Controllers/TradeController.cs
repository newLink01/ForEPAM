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
        private IEnumerable<FormattedSale> formattedSales;
        

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

        private IEnumerable<FormattedSale> SortedSale(string filter) {
            List<FormattedSale> BeforeSort = this.FormatSales().ToList();

            switch (filter) {
                case "Manager": {
                    return BeforeSort.OrderBy(x=>x.ManagerName);
                }
                case "Date": {
                    return BeforeSort.OrderBy(x => x.DateOfSale);  
                }
                case "Product": {
                    return BeforeSort.OrderBy(x => x.ProductName);
                }
                default: return null; 
            }

        }

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

        private IEnumerable<FormattedSale> FormatSales() {

            List<FormattedSale> FormattedSalesCollection = new List<FormattedSale>();

            FormattedSale formattedSale;

            foreach (var sale in this.saleRep.GetAll()) {
                formattedSale = new FormattedSale();
                formattedSale.SaleId = sale.SaleId;
                formattedSale.ManagerId = managerRep.GetElement(sale.Manager).ManagerId;
                formattedSale.ManagerName = managerRep.GetElement(sale.Manager).Name;
                formattedSale.ManagerSername = managerRep.GetElement(sale.Manager).Sername;
                formattedSale.ProductId = productRep.GetElement(sale.Product).ProductId;
                formattedSale.ProductName = productRep.GetElement(sale.Product).Name;
                formattedSale.AmountForSale = sale.AmountForSale;
                formattedSale.CostPerUnit = sale.CostPerUnit;
                formattedSale.DateOfSale = sale.DateOfSale;


                FormattedSalesCollection.Add(formattedSale);
            }

            return FormattedSalesCollection;
        }
        

        public ActionResult ShowManagers() {
            ViewBag.ManagerCollection = managerRep.GetAll();
            return View();
        }
        public ActionResult ShowProducts() {

            ViewBag.ProductCollection = productRep.GetAll();

            return View();
        }

        [HttpGet]
        public ActionResult ShowSales() {
            
            ViewBag.SaleCollection = this.FormatSales();
            return View();
}
        [HttpPost]
        public ActionResult ShowSales(SelectedFilterModel filter) {
                ViewBag.SaleCollection = this.SortedSale(filter.SelectedFilter);
                return View();
        }


    }
}
