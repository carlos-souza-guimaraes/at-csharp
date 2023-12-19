using LojaDeAlgumaCoisa.Data;
using LojaDeAlgumaCoisa.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaDeAlgumaCoisa.Services
{
    public class ModeloService
    {
        private readonly ApplicationDbContext _context;

        public ModeloService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Modelo> ObterTodos()
        {
            return _context.Modelo.ToList();
        }

        public Modelo Obter(int id)
        {
            var listaModelos = ObterTodos();
            var modelo = listaModelos.SingleOrDefault(item => item.Id == id);
            return modelo;
        }

        public async Task Adicionar(Modelo modelo)
        {
            _context.Modelo.Add(modelo);
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(int id)
        {
            var modelo = Obter(id);
            _context.Modelo.Remove(modelo);
            await _context.SaveChangesAsync();
        }

        public async Task Editar(Modelo modelo)
        {
            _context.Attach(modelo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
