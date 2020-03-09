using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RestaurantApp.core
{
    public class Restaurant
    {
        [Key]
        public int resId { get; set; }
        [Required]
        [StringLength(80)]
        public string resName { get; set; }
        [Required,StringLength(255)]
        public string resLocation { get; set; }
        public CuisinType CuisinType { get; set; }

    }
}
