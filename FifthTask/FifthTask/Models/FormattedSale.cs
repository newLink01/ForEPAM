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
        public Manager Manager { set; get; }
        public Product Product { set; get; }
        public int AmountForSale { set; get; }
        public double CostPerUnit { set; get; }
        public DateTime DateOfSale { set; get; }
    }
}