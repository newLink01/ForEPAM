using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace FifthTask.Models
{
    public class ManagerModel
    {
        [Required]
        [MinLength(2),MaxLength(20)]
        [Display(Name = "Name")]
        public string ManagerName { set; get; }

        [Required]
        [MinLength(2),MaxLength(30)]
        [Display(Name = "Sername")]
        public string ManagerSername { set; get; }
    }
}