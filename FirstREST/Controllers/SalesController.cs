﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstREST.Lib_Primavera.Model;


namespace FirstREST.Controllers
{
    public class SalesController : ApiController
    {
        //
        // GET: api/Sales

        public IEnumerable<Lib_Primavera.Model.DocVenda> Get()
        {
            return Lib_Primavera.PriIntegration.Encomendas_List();
        }


        // GET api/Sales/NumDoc    
        public Lib_Primavera.Model.DocVenda Get(string id)
        {
            Lib_Primavera.Model.DocVenda docvenda = Lib_Primavera.PriIntegration.Encomenda_Get(id);
            if (docvenda == null)
            {
                throw new HttpResponseException(
                        Request.CreateResponse(HttpStatusCode.NotFound));

            }
            else
            {
               //Lib_Primavera.PriIntegration.Encomendas_Transforma(Lib_Primavera.PriIntegration.DocvendaToBEDocVenda(docvenda));
                return docvenda;
            }
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
