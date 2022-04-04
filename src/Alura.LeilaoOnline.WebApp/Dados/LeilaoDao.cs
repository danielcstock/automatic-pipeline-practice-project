using System.Collections.Generic;
using System.Linq;
using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Alura.LeilaoOnline.WebApp.Dados;

public class LeilaoDao
{
    private AppDbContext _context;

    public LeilaoDao()
    {
        _context = new AppDbContext();
    }
    public IEnumerable<Categoria> BuscarCategorias()
    {
        return _context.Categorias.ToList();
    }

    public IEnumerable<Leilao> BuscarLeiloes()
    {
        return _context.Leiloes
            .Include(l => l.Categoria);
    }

    public Leilao BuscarLeilaoPorId(int id)
    {
        return _context.Leiloes.First(leilao => leilao.Id == id);
    }

    public void AdicionarLeilao(Leilao leilao)
    {
        _context.Leiloes.Add(leilao);
        _context.SaveChanges();
    }
    
    public void AtualizarLeilao(Leilao leilao)
    {
        _context.Leiloes.Update(leilao);
        _context.SaveChanges();
    }

    public void ApagarLeilao(Leilao leilao)
    {
        _context.Leiloes.Remove(leilao);
        _context.SaveChanges();
    }
}