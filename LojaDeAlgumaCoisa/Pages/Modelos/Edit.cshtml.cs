using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LojaDeAlgumaCoisa.Data;
using LojaDeAlgumaCoisa.Models;
using LojaDeAlgumaCoisa.Services;

namespace LojaDeAlgumaCoisa.Pages.Modelos
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Modelo Modelo { get; set; } = default!;
        private readonly ModeloService _modeloService;

        public EditModel(CarroService carroService, ModeloService modeloService)
        {
            _modeloService = modeloService;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _modeloService.ObterTodos() == null)
            {
                return NotFound();
            }

            Modelo = _modeloService.Obter((int)id);

            if (Modelo == null)
            {
                return NotFound();
            }

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

            try
            {
                await _modeloService.Editar(Modelo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeloExists(Modelo.Id))
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

        private bool ModeloExists(int id)
        {
            return _modeloService.Obter(id) != null;
        }
    }
}
