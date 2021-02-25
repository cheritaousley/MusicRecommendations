using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicRecommendations.Data;
using MusicRecommendations.Models;

namespace MusicRecommendations.Pages.Recommendations
{
    public class CreateModel : PageModel
    {
        private readonly MusicRecommendations.Data.MusicRecommendationsContext _context;

        public CreateModel(MusicRecommendations.Data.MusicRecommendationsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MusicModel MusicModel { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MusicModel.Add(MusicModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
