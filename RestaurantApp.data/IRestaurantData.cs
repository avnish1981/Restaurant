using RestaurantApp.core;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.data
{
    public interface IRestaurantData
    {
        //IEnumerable<Restaurant> GetAllRestaurants(); 
        IEnumerable<Restaurant> GetAllRestaurantsByName(string resname);
        Restaurant GetbyId(int id);
        Restaurant Updated(Restaurant updatedRestaurant);
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Delete(int id);
        int commit();
    }
}
