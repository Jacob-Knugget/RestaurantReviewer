using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantReviewer.Data;
using RestaurantReviewer.Models;

namespace RestaurantReviewer.Pages.Sakura
{
    public class IndexModel : PageModel
    {
        private readonly RestaurantReviewer.Data.RestaurantReviewerContext _context;

        public IndexModel(RestaurantReviewer.Data.RestaurantReviewerContext context)
        {
            _context = context;
        }

        public IList<Restaurants> Restaurants { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Types {  get; set; }
        [BindProperty(SupportsGet = true)]
        public string RestaurantType { get; set; }
        public string RatingSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            RatingSort = sortOrder;
            //Use LINQ to get list of types.

            IQueryable<string> typeQuery = from t in _context.Restaurants
                                           orderby t.Type
                                           select t.Type;

            var restaurants = from r in _context.Restaurants
                              select r;

            if (!string.IsNullOrEmpty(SearchString))
            {
                restaurants = restaurants.Where(r => r.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(RestaurantType))
            {
                restaurants = restaurants.Where(r => r.Type == RestaurantType);
            }

            if (sortOrder == "desc")
            {
                restaurants = restaurants.OrderByDescending(r => r.Rating);
            }

            Types = new SelectList(await typeQuery.Distinct().ToListAsync());
            Restaurants = await restaurants.AsNoTracking().ToListAsync();
        }
    }
}
