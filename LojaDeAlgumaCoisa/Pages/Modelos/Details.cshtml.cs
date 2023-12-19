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
    public class DetailsModel : PageModel
    {
        private readonly ModeloService _modeloService;
        public Modelo Modelo { get; set; }

        public DetailsModel(ModeloService modeloService)
        {
            _modeloService = modeloService;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
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
    }
}
