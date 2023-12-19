using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LojaDeAlgumaCoisa.Data;
using LojaDeAlgumaCoisa.Models;
using LojaDeAlgumaCoisa.Services;

namespace LojaDeAlgumaCoisa.Pages.Modelos
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Modelo Modelo { get; set; } = default!;
        private readonly ModeloService _modeloService;

        public DeleteModel(ModeloService modeloService)
        {
            _modeloService = modeloService;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _modeloService.ObterTodos() == null)
            {
                return NotFound();
            }

            var modelo = _modeloService.Obter((int)id);

            if (modelo == null)
            {
                return NotFound();
            }
            else
            {
                Modelo = modelo;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _modeloService.ObterTodos() == null)
            {
                return NotFound();
            }

            var modelo = _modeloService.Obter((int)id);

            if (modelo != null)
            {
                Modelo = modelo;
                await _modeloService.Deletar(Modelo.Id);
            }

            return RedirectToPage("./Index");
        }
    }
}
