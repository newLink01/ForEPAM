using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace FifthTask.Models
{
    public class ProductModel
    {
        [Required]
        [MinLength(5),MaxLength(100)]
        [Display(Name = "Name")]
        public string ProductName { set; get; }

        [MaxLength(200)]
        public string Description { set; get; }

    }
}