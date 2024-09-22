using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestaurantReviewer.Data;
using RestaurantReviewer.Models;

namespace RestaurantReviewer.Pages.Jacob
{
    public class IndexModel : PageModel
    {
        private readonly RestaurantReviewer.Data.RestaurantReviewerContext _context;

        public IndexModel(RestaurantReviewer.Data.RestaurantReviewerContext context)
        {
            _context = context;
        }

        public IList<Restaurants> Restaurants { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Restaurants != null)
            {
                Restaurants = await _context.Restaurants.ToListAsync();
            }
        }
    }
}
