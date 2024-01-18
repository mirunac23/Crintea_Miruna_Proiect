using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Crintea_Miruna_Proiect.Data;
using Crintea_Miruna_Proiect.Models;

namespace Crintea_Miruna_Proiect.Pages.Coaches
{
    public class CreateModel : PageModel
    {
        private readonly Crintea_Miruna_Proiect.Data.Crintea_Miruna_ProiectContext _context;

        public CreateModel(Crintea_Miruna_Proiect.Data.Crintea_Miruna_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Coach Coach { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Coach == null || Coach == null)
            {
                return Page();
            }

            _context.Coach.Add(Coach);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
