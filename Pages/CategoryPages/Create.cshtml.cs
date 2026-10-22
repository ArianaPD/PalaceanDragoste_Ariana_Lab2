using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PalaceanDragoste_Ariana_Lab2.Models;
using PalaceanDragoste_Ariana_Lab2.Data;

namespace PalaceanDragoste_Ariana_Lab2.Pages.CategoryPages
{
    public class CreateModel : PageModel
    {
        private readonly PalaceanDragoste_Ariana_Lab2Context _context;

        public CreateModel(PalaceanDragoste_Ariana_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Category.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
