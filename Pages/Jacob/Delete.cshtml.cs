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
    public class DeleteModel : PageModel
    {
        private readonly RestaurantReviewer.Data.RestaurantReviewerContext _context;

        public DeleteModel(RestaurantReviewer.Data.RestaurantReviewerContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Restaurants Restaurants { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Restaurants == null)
            {
                return NotFound();
            }

            var restaurants = await _context.Restaurants.FirstOrDefaultAsync(m => m.ID == id);

            if (restaurants == null)
            {
                return NotFound();
            }
            else 
            {
                Restaurants = restaurants;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Restaurants == null)
            {
                return NotFound();
            }
            var restaurants = await _context.Restaurants.FindAsync(id);

            if (restaurants != null)
            {
                Restaurants = restaurants;
                _context.Restaurants.Remove(Restaurants);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
