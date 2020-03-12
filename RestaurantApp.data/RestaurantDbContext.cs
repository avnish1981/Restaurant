using Microsoft.EntityFrameworkCore;
using RestaurantApp.core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.data
{
    public class RestaurantDbContext :DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options ) :base(options )
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }


    }
}
