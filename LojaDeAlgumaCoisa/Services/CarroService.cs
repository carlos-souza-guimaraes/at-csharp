

using LojaDeAlgumaCoisa.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace LojaDeAlgumaCoisa.Services;

public class CarroService
{
    private readonly ApplicationDbContext _context;

    public CarroService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Carro> ObterTodos()
    {
        return _context.Carro.ToList();
    }

    public Carro Obter(int id)
    {
        var listaCarro = ObterTodos();
        var carro = listaCarro.SingleOrDefault(item => item.Id == id);
        return carro;
    }
        public async Task Adicionar(Carro carro)
    {
        _context.Carro.Add(carro);
        await _context.SaveChangesAsync();
    }

    public async Task Deletar(int id)
    {
        var carro = Obter(id);
        _context.Carro.Remove(carro);
        await _context.SaveChangesAsync();
    }

    public async Task Editar(Carro carro)
    {
        _context.Attach(carro).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
        
    }
