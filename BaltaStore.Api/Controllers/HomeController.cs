using System;
using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.Api.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        //[Route("clientes")] //Listar todos os clientes
        //[Route("clientes/2587")] //Listar cliente 2587
        //[Route("clientes/2587/pedidos")] //pedidos do cliente 2587
        public object Get()
        {
            return new { Version = "0.0.1" };
        }


        [HttpGet]
        [Route("error")]
        //[Route("clientes")] //Listar todos os clientes
        //[Route("clientes/2587")] //Listar cliente 2587
        //[Route("clientes/2587/pedidos")] //pedidos do cliente 2587
        public string Error()
        {
            throw new Exception("Algum ocorreu");
            return  "errro";
        }


        ////Diferenciamos as rotas pelo verbo HTTP em cima da action!
        //[HttpGet]
        //[Route("rota/01")]
        //public object Get()
        //{
        //    return new {Version = "0.0.1"};
        //}

        //[HttpPost]
        //[Route("rota/01")]
        //public object Post()
        //{
        //    return new { Version = "0.0.1" };
        //}
    }
}