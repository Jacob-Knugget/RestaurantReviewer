using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RestaurantReviewer.Data;
using RestaurantReviewer.Models;

namespace RestaurantReviewer.Pages.Dylan
{
    public class IndexModel : PageModel
    {
        private readonly RestaurantReviewer.Data.RestaurantReviewerContext _context;

        public IndexModel(RestaurantReviewer.Data.RestaurantReviewerContext context)
        {
            _context = context;
        }

        public IList<Restaurants> Restaurants { get; set; } = default;
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public string RatingSort { get; set; }
        public string TypeSort { get; set; }
        public async Task OnGetAsync(string sortOrder)
        {
            RatingSort = String.IsNullOrEmpty(sortOrder) ? "RatingDesc" : "";
            TypeSort = sortOrder == "TypeAsc" ? "TypeDesc" : "";
            var resources = from r in _context.Restaurants
                            select r;
            if (!string.IsNullOrEmpty(SearchString))
            {
                resources = resources.Where(r => r.Type.Contains(SearchString));
            }
            switch (sortOrder)
            {
                case "RatingDesc":
                    resources = resources.OrderByDescending(r => r.Rating);
                    break;
                case "TypeDesc":
                    resources = resources.OrderByDescending(r => r.Type);
                    break;
                case "TypeAsc":
                    resources = resources.OrderBy(r => r.Type);
                    break;
                default:
                    resources = resources.OrderBy(r => r.Rating);
                    break;
            }

            Restaurants = await resources.ToListAsync();

        }
    }
}
