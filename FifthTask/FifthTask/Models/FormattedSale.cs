using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FifthTask.DAL.Entities;

namespace FifthTask.Models
{
    public class FormattedSale
    {
        public int SaleId { set; get; }
        public int ManagerId { set; get; }
        public string ManagerName { set; get; }
        public string ManagerSername { set; get; }
        public int ProductId { set; get; }
        public string ProductName { set; get; }
        public int AmountForSale { set; get; }
        public double CostPerUnit { set; get; }
        public DateTime DateOfSale { set; get; }
    }
}