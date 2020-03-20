using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RestaurantApp.data;

namespace RestaurantApplication.Pages.Restaurant
{
    public class ListModel : PageModel
    {
        private readonly IRestaurantData restaurantData = null;
        private readonly ILogger<ListModel> logger;

        public IEnumerable<RestaurantApp.core.Restaurant > prorestaurants { get; set; }
        [BindProperty(SupportsGet = true )]
        public string SearchTerm { get; set; }
        public ListModel(IRestaurantData restaurantData,ILogger<ListModel> logger )
        {
            this.restaurantData = restaurantData;
            this.logger = logger;
        }
        public void OnGet( )
        {
            logger.LogInformation ("Execting ListModel");
            // prorestaurants = restaurantData.GetAllRestaurants();
            prorestaurants = restaurantData.GetAllRestaurantsByName(SearchTerm);

        }
    }
}