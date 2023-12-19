using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LojaDeAlgumaCoisa.Data;
using LojaDeAlgumaCoisa.Services;

namespace LojaDeAlgumaCoisa.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly CarroService _carroService;
        public Carro Carro { get; set; }

        public DetailsModel(CarroService carroService)
        {
            _carroService = carroService;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
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
    }

}
