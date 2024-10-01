using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantReviewer.Data;
using RestaurantReviewer.Models;

namespace RestaurantReviewer.Pages.Jacob
{
    public class CreateModel : PageModel
    {
        private readonly RestaurantReviewer.Data.RestaurantReviewerContext _context;

        [BindProperty]
        public Restaurants? ImageData { get; set; }

        public CreateModel(RestaurantReviewer.Data.RestaurantReviewerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Restaurants Restaurants { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Restaurants == null || Restaurants == null)
            {
                return Page();
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

            _context.Restaurants.Add(ImageData);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
