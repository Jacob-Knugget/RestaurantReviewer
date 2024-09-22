using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantReviewer.Models;

namespace RestaurantReviewer.Data
{
    public class RestaurantReviewerContext : DbContext
    {
        public RestaurantReviewerContext (DbContextOptions<RestaurantReviewerContext> options)
            : base(options)
        {
        }

        public DbSet<RestaurantReviewer.Models.Restaurants> Restaurants { get; set; } = default!;
    }
}
