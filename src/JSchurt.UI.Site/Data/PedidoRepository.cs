using JSchurt.UI.Site.Models;

namespace JSchurt.UI.Site.Data
{
    public class PedidoRepository :  IPedidoRepository
    {


        public Pedido ObterPedido()
        {
            return new Pedido();
        }

    } //class
     
    public interface IPedidoRepository
    {
        Pedido ObterPedido();
    } //interface

} //namespace


