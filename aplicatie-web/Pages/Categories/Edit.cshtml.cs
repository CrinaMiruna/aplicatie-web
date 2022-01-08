using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aplicatie_web.Data;
using aplicatie_web.Models;

namespace aplicatie_web.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly aplicatie_web.Data.aplicatie_webContext _context;

        public EditModel(aplicatie_web.Data.aplicatie_webContext context)
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
           ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "ID", "ID");
           ViewData["ProgramareID"] = new SelectList(_context.Programare, "ID", "ID");
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

            _context.Attach(ProgramareCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramareCategoryExists(ProgramareCategory.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProgramareCategoryExists(int id)
        {
            return _context.ProgramareCategory.Any(e => e.ID == id);
        }
    }
}
