using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LojaDeAlgumaCoisa.Data;
using LojaDeAlgumaCoisa.Services;
using Microsoft.AspNetCore.Authorization;

namespace LojaDeAlgumaCoisa.Pages
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Carro Carro { get; set; } = default!;
        private readonly CarroService _carroService;

        public DeleteModel(CarroService carroService)
        {
            _carroService = carroService;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _carroService.ObterTodos() == null)
            {
                return NotFound();
            }

            var carro = _carroService.Obter((int)id);

            if (carro == null)
            {
                return NotFound();
            }
            else
            {
                Carro = carro;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _carroService.ObterTodos() == null)
            {
                return NotFound();
            }

            var carro =  _carroService.Obter((int)id);

            if (carro != null)
            {
                Carro = carro;
                await _carroService.Deletar(carro.Id);
            }

            return RedirectToPage("./Index");
        }
    }
}
