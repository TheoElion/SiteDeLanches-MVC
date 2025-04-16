using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;

namespace LanchesMac.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly AppDbConxtex _appDbConxtex;
    private readonly CarrinhoCompra _carrinhoCompra;

    public PedidoRepository(AppDbConxtex appDbConxtex, CarrinhoCompra carrinhoCompra)
    {
        _appDbConxtex = appDbConxtex;
        _carrinhoCompra = carrinhoCompra;
    }

    public void CriarPedido(Pedido pedido)
    {
        pedido.PedidoEnviado = DateTime.Now;
        _appDbConxtex.Pedidos.Add(pedido);
        _appDbConxtex.SaveChanges();

        var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItens;

        foreach (var carrinhoItem in carrinhoCompraItens)
        {
            var pedidoDetail = new PedidoDetalhe()
            {
                Quantidade = carrinhoItem.Quantidade,
                LancheId = carrinhoItem.Lanche.LancheId,
                PedidoId = pedido.PedidoId,
                Preco = carrinhoItem.Lanche.Preco
            };
            _appDbConxtex.PedidoDetalhes.Add(pedidoDetail);
        }
        _appDbConxtex.SaveChanges();
    }
}
