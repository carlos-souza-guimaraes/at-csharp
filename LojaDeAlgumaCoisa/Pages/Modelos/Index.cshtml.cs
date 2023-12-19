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
    public class IndexModel : PageModel
    {
        public IList<Modelo> ListaModelo { get; private set; }
        private readonly ModeloService _modeloService;

        public IndexModel(ModeloService modeloService)
        {
            _modeloService = modeloService;
        }

        public void OnGet()
        {
            ViewData["Title"] = "Home page";

            ListaModelo = _modeloService.ObterTodos();

        }
    }
}
