using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LojaDeAlgumaCoisa.Data;
using LojaDeAlgumaCoisa.Services;
using Microsoft.AspNetCore.Authorization;

namespace LojaDeAlgumaCoisa.Pages
{
    [Authorize]
    public class EditModel : PageModel
    {
        [BindProperty]
        public Carro Carro { get; set; } = default!;
        [BindProperty]
        public List<SelectListItem> Modelos { get; set; }
        private readonly CarroService _carroService;
        private readonly ModeloService _modeloService;

        public EditModel(CarroService carroService, ModeloService modeloService)
        {
            _carroService = carroService;
            _modeloService = modeloService;
            Modelos = _modeloService
            .ObterTodos()
            .Select(modelo => new SelectListItem { Value = modelo.Id.ToString(), Text = modelo.Name })
            .ToList();
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _carroService.ObterTodos() == null)
            {
                return NotFound();
            }

            Carro = _carroService.Obter((int)id);

            if (Carro == null)
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
                await _carroService.Editar(Carro);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarroExists(Carro.Id))
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

        private bool CarroExists(int id)
        {
            return _carroService.Obter(id) != null;
        }
    }
}
