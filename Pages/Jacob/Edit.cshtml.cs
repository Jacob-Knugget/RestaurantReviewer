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

namespace RestaurantReviewer.Pages.Jacob
{
    public class EditModel : PageModel
    {
        private readonly RestaurantReviewer.Data.RestaurantReviewerContext _context;

        public EditModel(RestaurantReviewer.Data.RestaurantReviewerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Restaurants Restaurants { get; set; } = default!;

        [BindProperty]
        public Restaurants? ImageData { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Restaurants == null)
            {
                return NotFound();
            }

            var restaurants =  await _context.Restaurants.FirstOrDefaultAsync(m => m.ID == id);
            if (restaurants == null)
            {
                return NotFound();
            }
            Restaurants = restaurants;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Restaurants).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantsExists(Restaurants.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            byte[] bytes = null;

            if (ImageData.ImageFile != null)
            {
                using (Stream fs = ImageData.ImageFile.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        bytes = br.ReadBytes((Int32)fs.Length);
                    }
                }
                ImageData.ImageData = Convert.ToBase64String(bytes, 0, bytes.Length);
            }

            return RedirectToPage("./Index");
        }

        private bool RestaurantsExists(int id)
        {
          return (_context.Restaurants?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
