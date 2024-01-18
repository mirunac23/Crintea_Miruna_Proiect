using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Crintea_Miruna_Proiect.Data;
using Crintea_Miruna_Proiect.Models;

namespace Crintea_Miruna_Proiect.Pages.ProgramElements
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
        ViewData["ElementID"] = new SelectList(_context.Element, "ID", "ID");
        ViewData["SkaterID"] = new SelectList(_context.Skater, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public ProgramElement ProgramElement { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ProgramElement == null || ProgramElement == null)
            {
                return Page();
            }

            _context.ProgramElement.Add(ProgramElement);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
