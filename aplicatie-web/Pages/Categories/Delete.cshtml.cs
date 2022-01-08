using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using aplicatie_web.Data;
using aplicatie_web.Models;

namespace aplicatie_web.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly aplicatie_web.Data.aplicatie_webContext _context;

        public DeleteModel(aplicatie_web.Data.aplicatie_webContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProgramareCategory ProgramareCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProgramareCategory = await _context.ProgramareCategory
                .Include(p => p.Category)
                .Include(p => p.Programare).FirstOrDefaultAsync(m => m.ID == id);

            if (ProgramareCategory == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProgramareCategory = await _context.ProgramareCategory.FindAsync(id);

            if (ProgramareCategory != null)
            {
                _context.ProgramareCategory.Remove(ProgramareCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
