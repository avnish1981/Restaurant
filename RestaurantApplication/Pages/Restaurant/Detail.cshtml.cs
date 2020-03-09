using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantApp.data;

namespace RestaurantApplication.Pages.Restaurant
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        [TempData]
        public string disMessage { get; set; } 

        public RestaurantApp.core.Restaurant  restaurant { get; set; }

        public DetailModel(IRestaurantData restaurantData )
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int restaurantId)
        {
            
            restaurant = restaurantData.GetbyId(restaurantId);
            if(restaurant==null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}