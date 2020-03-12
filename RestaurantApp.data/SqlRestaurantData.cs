using System.Collections.Generic;
using RestaurantApp.core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RestaurantApp.data
{
    public class SqlRestaurantData : IRestaurantData
    {
        readonly RestaurantDbContext db = null;

        public SqlRestaurantData(RestaurantDbContext db)
        {
            this.db = db;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            //return  db.Restaurants.Add(newRestaurant);
            db.Add(newRestaurant);
            return newRestaurant;
        }

        public int commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetbyId(id);
            if (restaurant !=null)
            {
                db.Restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public IEnumerable<Restaurant> GetAllRestaurantsByName(string resname)
        {
            var query = from r in db.Restaurants
                        where r.resName.StartsWith(resname) || string.IsNullOrEmpty(resname)
                        orderby r.resName 
                        select r;

            return query;
        }

        public Restaurant GetbyId(int id)
        {
            return db.Restaurants.Find(id);
        }

        public Restaurant Updated(Restaurant updatedRestaurant)
        {
            var entity = db.Restaurants.Attach(updatedRestaurant);

            entity.State = EntityState.Modified;

            return updatedRestaurant;
        }
    }
}
