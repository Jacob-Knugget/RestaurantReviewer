using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestaurantReviewer.Data;
using RestaurantReviewer.Models;

namespace RestaurantReviewer.Pages.Soren
{
    public class IndexModel : PageModel
    {
        private readonly RestaurantReviewer.Data.RestaurantReviewerContext _context;

        public IndexModel(RestaurantReviewer.Data.RestaurantReviewerContext context)
        {
            _context = context;
        }

        public IList<Restaurants> Restaurants { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public string TitleSort { get; set; }
        public string TypeSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            TitleSort = string.IsNullOrEmpty(sortOrder) ? "TitleDesc" : "";
            TypeSort = string.IsNullOrEmpty(sortOrder) ? "TypeDesc" : "TypeAsc";


            var restaurants = from r in _context.Restaurants
                              select r;
            if (!string.IsNullOrEmpty(SearchString))
            {
                restaurants = restaurants.Where(r => r.Name.Contains(SearchString));
            }
            switch (sortOrder)
            {
                case "TitleDesc":
                    restaurants = restaurants.OrderByDescending(r => r.Name);
                    break;
                case "TypeDesc":
                    restaurants = restaurants.OrderByDescending(r => r.Type);
                    break;
                case "TypeAsc":
                    restaurants = restaurants.OrderBy(r => r.Type);
                    break;
                default:
                    restaurants = restaurants.OrderBy(r => r.Name);
                    break;
            }


            Restaurants = await restaurants.ToListAsync();
        }
    }
}
