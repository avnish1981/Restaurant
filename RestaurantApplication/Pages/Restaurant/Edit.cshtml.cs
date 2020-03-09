using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantApp.data;
using RestaurantApp.core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RestaurantApplication.Pages.Restaurant
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;
        [BindProperty ]
        public RestaurantApp.core.Restaurant proRestaurant { get; set; }
        public IEnumerable<SelectListItem > cusines { get; set; }
        public EditModel(IRestaurantData restaurantData,IHtmlHelper htmlHelper )
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult  OnGet(int ? restaurantId)
        {
            
            cusines = htmlHelper.GetEnumSelectList<CuisinType>();
            if(restaurantId.HasValue)
            {
                proRestaurant = restaurantData.GetbyId(restaurantId.Value );
            }
            else
            {
                proRestaurant = new RestaurantApp.core.Restaurant();
            }
           
            if (proRestaurant==null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                cusines = htmlHelper.GetEnumSelectList<CuisinType>();
                return Page();
                

            }

            if(proRestaurant.resId> 0 )
            {
                restaurantData.Updated(proRestaurant);
               
            }
            else
            {
                restaurantData.Add(proRestaurant);
            }

            restaurantData.commit();
            TempData["disMessage"] = "Restuarant Saved !";
            return RedirectToPage("./Detail", new { restaurantId = proRestaurant.resId });

        }
    }
}