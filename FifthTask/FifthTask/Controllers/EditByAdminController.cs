using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FifthTask.Models;
using FifthTask.DAL.Repositories;
using FifthTask.DAL.Entities;
namespace FifthTask.Controllers
{
    
    public class EditByAdminController : Controller
    {
        
        //
        // GET: /EditByAdmin/
        private ManagerRepository managerRep;
        private ProductRepository productRep;
        private SaleRepository saleRep;
        public EditByAdminController() {
            this.saleRep = new SaleRepository();
            this. managerRep = new ManagerRepository();
            this.productRep = new ProductRepository();
        }

        public ActionResult EditRecords()
        {
            
            return View();
        }

        


        [HttpGet]
        public ActionResult AddManager() {
            return View();    
        }
        [HttpPost]
        public ActionResult AddManager(ManagerModel manager) {
           
            if (manager!=null && ModelState.IsValid)
            {
                managerRep.Create(new Manager() { Name = manager.ManagerName, Sername = manager.ManagerSername});
                managerRep.Save();
                return View();
            }
            return View();
        }

        [HttpGet]
        public ActionResult RemoveManager() {
            return View();
        }
        [HttpPost]
        public ActionResult RemoveManager(ForDropByIdModel info) {
            if (ModelState.IsValid)
            {
                managerRep.Delete(info.ElementId);
                managerRep.Save();
                return View();
            }
            return View();
        }

        [HttpGet]
        public ActionResult AddProduct() {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(ProductModel product) {
            if (ModelState.IsValid && product != null) {

                this.productRep.Create(new Product()
                {
                    Name = product.ProductName,
                    Description = product.Description, 
                });
                this.productRep.Save();
                return View();
            }
            return View();
        }


        [HttpGet]
        public ActionResult RemoveProduct() {
            return View();
        }
        [HttpPost]
        public ActionResult RemoveProduct(ForDropByIdModel info) {
            if (ModelState.IsValid) {
                productRep.Delete(info.ElementId);
                productRep.Save();
                return View();
            }
            return View();
        }


        [HttpGet]
        public ActionResult AddSale() {
           
            return View();
        }

        [HttpPost]
        public ActionResult AddSale(SaleModel sale) { //check for AmountForSale
            if (ModelState.IsValid && sale != null) {

                var forAddSale = saleRep.CreateStandAloneElement();

                foreach (var manager in managerRep.GetAll()) {
                    if (sale.ManagerId == manager.ManagerId)
                        forAddSale.Manager = sale.ManagerId;
                }
                foreach (var product in productRep.GetAll()) {
                    if (sale.ProductId == product.ProductId)
                        forAddSale.Product = sale.ProductId;
                }
                forAddSale.AmountForSale = sale.AmountForSale;
                forAddSale.CostPerUnit = sale.CostPerUnit;
                forAddSale.DateOfSale = sale.DateOfSale;

                if (forAddSale.Manager != null && forAddSale.Product != null)
                {
                    //this.productRep.Save();
                    this.saleRep.Save();
                    return View();
                }
                    }
            return View();
        }

        [HttpGet]
        public ActionResult RemoveSale() {
            return View();
        }
        [HttpPost]
        public ActionResult RemoveSale(ForDropByIdModel info) {
            if (ModelState.IsValid && info != null) {
                saleRep.Delete(info.ElementId);
                saleRep.Save();
                return View("EditRecords");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditProduct() {
            return View();
        }






        [HttpGet]
        public ActionResult AddRole() { 
            
            return View();
        }


    }
}
