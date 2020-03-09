using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantApp.data;

namespace RestaurantApplication.Pages.Restaurant
{
    public class ListModel : PageModel
    {
        private readonly IRestaurantData restaurantData = null;
        public IEnumerable<RestaurantApp.core.Restaurant > prorestaurants { get; set; }
        [BindProperty(SupportsGet = true )]
        public string SearchTerm { get; set; }
        public ListModel(IRestaurantData restaurantData )
        {
            this.restaurantData = restaurantData;
        }
        public void OnGet( )
        {

            // prorestaurants = restaurantData.GetAllRestaurants();
            prorestaurants = restaurantData.GetAllRestaurantsByName(SearchTerm);

        }
    }
}