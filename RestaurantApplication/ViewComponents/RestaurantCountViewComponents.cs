using Microsoft.AspNetCore.Mvc;
using RestaurantApp.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApplication.ViewComponents
{
    public class RestaurantCountViewComponents:ViewComponent
    {
        private readonly IRestaurantData restaurantData;

        public RestaurantCountViewComponents(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IViewComponentResult Invoke()
        {
            var count = restaurantData.GetTotalRestaurantCount();
            return View("Default",count );
        }

       
    }
}
