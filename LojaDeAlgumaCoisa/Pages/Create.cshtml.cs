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
using Microsoft.AspNetCore.Authorization;

namespace LojaDeAlgumaCoisa.Pages
{
    [Authorize]
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Carro Carro { get; set; } = default!;
        [BindProperty]
        public List<SelectListItem> Modelos { get; set; }
        private readonly CarroService _carroService;
        private readonly ModeloService _modeloService;

        public CreateModel(CarroService carroService, ModeloService modeloService)
        {
            _carroService = carroService;
            _modeloService = modeloService;
            Modelos = _modeloService
            .ObterTodos()
            .Select(modelo => new SelectListItem { Value = modelo.Id.ToString(), Text = modelo.Name })
            .ToList();
        }

        public IActionResult OnGet()
        {
            return Page();
        }




        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _carroService.ObterTodos() == null || Carro == null)
            {
                return Page();
            }

            await _carroService.Adicionar(Carro);

            return RedirectToPage("./Index");
        }
    }
}
