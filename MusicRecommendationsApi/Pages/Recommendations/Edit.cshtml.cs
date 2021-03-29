using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicRecommendations.Data;
using MusicRecommendations.Models;

namespace MusicRecommendations.Pages.Recommendations
{
    public class EditModel : PageModel
    {
        private readonly MusicRecommendations.Data.MusicRecommendationsContext _context;

        public EditModel(MusicRecommendations.Data.MusicRecommendationsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MusicModel MusicModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MusicModel = await _context.MusicModel.FirstOrDefaultAsync(m => m.Id == id);

            if (MusicModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MusicModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicModelExists(MusicModel.Id))
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

        private bool MusicModelExists(int id)
        {
            return _context.MusicModel.Any(e => e.Id == id);
        }
    }
}
