using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstREST.Controllers
{
    public class InvoicesController : ApiController
    {


        public IEnumerable<Lib_Primavera.Model.DocVenda> Get()
        {
            return Lib_Primavera.PriIntegration.Faturas_List();
        }

        // GET api/Invoices/NumDoc    
        public Boolean Get(string id)
        {
            return Lib_Primavera.PriIntegration.Faturas_Check(id);
        }


        public HttpResponseMessage Post(string id)
        {
            Lib_Primavera.Model.DocVenda dv = Lib_Primavera.PriIntegration.Encomenda_Get(id);
            Lib_Primavera.Model.RespostaErro erro = new Lib_Primavera.Model.RespostaErro();
            try
            {

                erro = Lib_Primavera.PriIntegration.Encomendas_New(dv);
                if (erro.Erro == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, erro.Descricao);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro.Descricao);
                }

            }

            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro.Descricao);

            }


        }
    }
}
