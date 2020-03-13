using RestaurantApp.core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantApp.data
{
    public class clsRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> objRes = null;
        public clsRestaurantData()
        {
            objRes = new List<Restaurant>
            {
                new Restaurant{resId=1,resName="Ïndia Dhaba" , resLocation="Noida",CuisinType=CuisinType.Indian },
                new Restaurant{resId=2,resName="Punjabi Dhaba" , resLocation="Delhi",CuisinType=CuisinType.Indian },
                new Restaurant{resId=3,resName="Maxican Curry" , resLocation="Noida",CuisinType=CuisinType.Maxican  },
                new Restaurant{resId=4,resName="maxican Golf Curry" , resLocation="Noida",CuisinType=CuisinType.Maxican },
                new Restaurant{resId=5,resName="Suji Italina" , resLocation="Noida",CuisinType=CuisinType.Italian  },
                new Restaurant{resId=6,resName="GS Italian" , resLocation="Noida",CuisinType=CuisinType.Italian },
                new Restaurant{resId=7,resName="Holf Maxican" , resLocation="Noida",CuisinType=CuisinType.Maxican },
                new Restaurant{resId=8,resName="Gujarati Dhaba" , resLocation="Noida",CuisinType=CuisinType.Indian },


            };
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
             objRes.Add(newRestaurant);
            newRestaurant.resId = objRes.Max(r => r.resId) + 1;
            return newRestaurant;
        }

        public int commit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = objRes.FirstOrDefault(r => r.resId == id);
            if(restaurant !=null)
            {
                objRes.Remove(restaurant);
            }

            return restaurant;
        }

        public IEnumerable<Restaurant> GetAllRestaurantsByName(string resname)
        {
            return from r in objRes
                   where string.IsNullOrEmpty(resname) || r.resName.StartsWith(resname)
                   orderby r.resName
                   select r;
        }

        public Restaurant GetbyId(int id)
        {
            return objRes.SingleOrDefault(r => r.resId == id);
        }

        public int GetTotalRestaurantCount()
        {
            return objRes.Count();
        }

        public Restaurant Updated(Restaurant updatedRestaurant)
        {
            var resdata = objRes.SingleOrDefault(r => r.resId == updatedRestaurant.resId);
            if(resdata !=null)
            {
                resdata.resName = updatedRestaurant.resName;
                resdata.resLocation = updatedRestaurant.resLocation;
                resdata.CuisinType = updatedRestaurant.CuisinType;

            }

            return resdata;


        }
        /* public IEnumerable<Restaurant> GetAllRestaurants()
{
return from r in objRes
orderby r.resName
select r;


} */

    }
}
