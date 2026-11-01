using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PalaceanDragoste_Ariana_Lab2.Models;
using PalaceanDragoste_Ariana_Lab2.Data;

namespace PalaceanDragoste_Ariana_Lab2.Pages.CategoryPages
{
    public class IndexModel : PageModel
    {
        private readonly PalaceanDragoste_Ariana_Lab2Context _context;

        public IndexModel(PalaceanDragoste_Ariana_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public CategoryIndexData CategoryIndexData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }

        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategoryIndexData = new CategoryIndexData();
            CategoryIndexData.Categories = await _context.Category
                .Include(i => i.BookCategories)
                    .ThenInclude(c => c.Book)
                        .ThenInclude(i => i.Publisher)
                .AsNoTracking()
                .OrderBy(i => i.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryIndexData.Categories
                    .Where(i => i.ID == id.Value).Single();
                CategoryIndexData.Books = category.BookCategories.Select(s => s.Book);
            }
        }
            }
}
