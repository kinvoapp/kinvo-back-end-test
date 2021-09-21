using Microsoft.AspNetCore.Mvc;
namespace Aliquota.Api.Controller
{
    [ApiController]
    [Route("v1/clients")]
    public class ProductController : ControllerBase
    {
        //O Command é recebido pelo corpo da requisição por json
        //From services vem do Startup e nele passamos um handler 

        //Sem tomada de decisões em controller (ex: IF's)
        //Assim o controller fica muito mais enxuto 
        //Já que precisa passar por um command e ser manipulado por um handler

    }
}