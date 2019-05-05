using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Product.Models
{
    public class product
    {
        [Required]
        public int Id { get; set; }
        [Display(Name ="Name")]
        [Required(ErrorMessage = "Please Enter Brand Name")]
        public string BrandName { get; set; }
        [Display(Name ="Model Number")]
        [Required(ErrorMessage = "Please Enter Model Number")]
        public string ModelNo { get; set; }
        [Display(Name ="Description")]
        public string Description { get; set; }
        //[Required]
        [Display(Name ="Quality")]
        public int? QualityId { get; set; }
        public virtual Quality Quality { get; set; }
    }
}