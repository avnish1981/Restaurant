using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantApp.data ;
using RestaurantApp.core;

namespace RestaurantApplication.Pages.Restaurant
{
    public class DeleteModel : PageModel
    {
        readonly IRestaurantData restaurantData = null;
        public RestaurantApp.core.Restaurant restaurant { get; set; }
        public DeleteModel(IRestaurantData restaurantData  )
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult  OnGet(int restaurantId)
        {
            restaurant = restaurantData.GetbyId(restaurantId);
            if(restaurant ==null)
            {
                RedirectToPage("./NotFound");
            }

            return Page();
        }
        
        public IActionResult OnPost(int restaurantId)
        {
            var restuarant = restaurantData.Delete(restaurantId);
            restaurantData.commit();
            if(restaurant == null)
            {
                return RedirectToPage("./NotFound");

            }
            TempData["disMessage"] = $"{restaurant.resName} deleted";

            return RedirectToPage("./List");
        }
    }
}