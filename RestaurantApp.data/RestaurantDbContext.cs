using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantApp.core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.data
{
    public class RestaurantDbContext :IdentityDbContext<IdentityUser>
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options ) :base(options )
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }


    }
}
