using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Teste_Signa.Controllers
{
    [Route("api/[controller]")]


    public class ConsultaSqlController : ApiController
    {

        private IConfiguration Configuration;
        public ConsultaSqlController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public HttpResponseMessage GetListaPessoas()
        {
            string Conexao_BD = Configuration.GetConnectionString("Conexao_teste");
            DataSet ds = new DataSet();
            List<Models.Pessoa> pessoas = new List<Models.Pessoa>();
            DAL.ConsultaSql dalConsulta = new DAL.ConsultaSql();

            try
            {
                pessoas = dalConsulta.GetListaPessoas(Conexao_BD);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.NoContent, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, pessoas);
          
        }
    }
}
