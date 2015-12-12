using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace FifthTask.Models
{
    public class SaleModel
    {
        [Required]
        public int ManagerId { set; get; }
        [Required]
        public int ProductId { set; get; }
        [Required]
        public int AmountForSale { set; get; }
        [Required]
        public double CostPerUnit { set; get; }
        [Required]
        public DateTime DateOfSale { set; get; }
    }
}