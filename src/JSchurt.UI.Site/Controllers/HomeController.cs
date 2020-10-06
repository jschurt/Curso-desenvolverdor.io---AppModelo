using JSchurt.UI.Site.Data;
using JSchurt.UI.Site.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JSchurt.UI.Site.Controllers
{
    public class HomeController : Controller
    {

        //Testando tipos de injecao de dependencia
        public OperacaoService operacaoService { get;  }
        public OperacaoService operacaoService2 { get; }

        public HomeController(OperacaoService operacaoService, OperacaoService operacaoService2)
        {
            this.operacaoService = operacaoService ?? throw new ArgumentNullException(nameof(operacaoService));
            this.operacaoService2 = operacaoService2 ?? throw new ArgumentNullException(nameof(operacaoService2));
        }


        //Caso eu nao possa injetar diretamente na classe (por algum motivo especifico), posso injetar 
        //diretamente no metodo (nao e o recomendado)
        public IActionResult Teste([FromServices] IPedidoRepository _pedidoRepository)
        {

            var pedido = _pedidoRepository.ObterPedido();

            return View();
        }

        public string Index()
        {

            return
                $"Primeira Instancia: {Environment.NewLine}" +
                $"{operacaoService.Transient.OperacaoId} {Environment.NewLine}" +
                $"{operacaoService.Scoped.OperacaoId} {Environment.NewLine}" +
                $"{operacaoService.Singleton.OperacaoId} {Environment.NewLine}" +
                $"{operacaoService.SingletoneInstance.OperacaoId} {Environment.NewLine}" +
                
                $"{Environment.NewLine}{Environment.NewLine}" +
                
                $"Segunda Instancia: {Environment.NewLine}" +
                $"{operacaoService2.Transient.OperacaoId} {Environment.NewLine}" +
                $"{operacaoService2.Scoped.OperacaoId} {Environment.NewLine}" +
                $"{operacaoService2.Singleton.OperacaoId} {Environment.NewLine}" +
                $"{operacaoService2.SingletoneInstance.OperacaoId} {Environment.NewLine}";


        }



    }
}
