using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Media;
namespace FifthTask.Models
{
    public class SaleModel
    {
        [Required]
        [Display(Name = "Manager id")]
        public int ManagerId { set; get; }

        [Required]
        [Display(Name = "Product id")]
        public int ProductId { set; get; }

        [Required]
        [Display(Name = "Amount for sale")]
        public int AmountForSale { set; get; }

        [Required]
        [Display(Name = "Cost per unit")]
        public double CostPerUnit { set; get; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of sale")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:g}")]
        public DateTime DateOfSale { set; get; }
    }
}