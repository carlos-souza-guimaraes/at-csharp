using LojaDeAlgumaCoisa.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LojaDeAlgumaCoisa.Pages;

public class IndexModel : PageModel
{
    public IList<Carro> ListaCarro { get; private set; }
    private readonly CarroService _carroService;

    public IndexModel(CarroService carroService)
    {
        _carroService = carroService;
    }

    public void OnGet()
    {
        ViewData["Title"] = "Home page";

        ListaCarro = _carroService.ObterTodos();

    }
}