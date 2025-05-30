﻿using LanchesMac.Context;
using LanchesMac.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace LanchesMac.Areas.Admin.Servicos;

public class RelatorioVendasService
{
    private readonly AppDbConxtex _context;

    public RelatorioVendasService(AppDbConxtex context)
    {
        _context = context;
    }

    public async Task<List<Pedido>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
    {
        var resultado = from obj in _context.Pedidos select obj;

        if (!minDate.HasValue)
        {
            resultado = resultado.Where(x => x.PedidoEnviado >= minDate.Value);
        }

        if (!maxDate.HasValue)
        {
            resultado = resultado.Where(x => x.PedidoEnviado >= maxDate.Value);
        }

        return await resultado
                .Include(l => l.PedidoItens)
                .ThenInclude(l => l.Lanche)
                .OrderByDescending(x => x.PedidoEnviado)
                .ToListAsync();
    }
}
