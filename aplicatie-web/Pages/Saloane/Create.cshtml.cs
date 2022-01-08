﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using aplicatie_web.Data;
using aplicatie_web.Models;

namespace aplicatie_web.Pages.Saloane
{
    public class CreateModel : PageModel
    {
        private readonly aplicatie_web.Data.aplicatie_webContext _context;

        public CreateModel(aplicatie_web.Data.aplicatie_webContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Salon Salon { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Salon.Add(Salon);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
