using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LojaDeAlgumaCoisa.Data;
using LojaDeAlgumaCoisa.Models;
using LojaDeAlgumaCoisa.Services;

namespace LojaDeAlgumaCoisa.Pages.Modelos
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Modelo Modelo { get; set; } = default!;
        private readonly ModeloService _modeloService;

        public CreateModel(ModeloService modeloService)
        {;
            _modeloService = modeloService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _modeloService.ObterTodos() == null || Modelo == null)
            {
                return Page();
            }

            await _modeloService.Adicionar(Modelo);

            return RedirectToPage("./Index");
        }
    }
}
