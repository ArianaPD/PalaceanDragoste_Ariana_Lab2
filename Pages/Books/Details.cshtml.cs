using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PalaceanDragoste_Ariana_Lab2.Models;
using PalaceanDragoste_Ariana_Lab2.Data;

namespace PalaceanDragoste_Ariana_Lab2.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly PalaceanDragoste_Ariana_Lab2Context _context;

        public DetailsModel(PalaceanDragoste_Ariana_Lab2Context context)
        {
            _context = context;
        }

        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Include(b => b.BookCategories)
                    .ThenInclude(b => b.Category)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (book is not null)
            {
                Book = book;

                return Page();
            }

            return NotFound();
        }
    }
}
