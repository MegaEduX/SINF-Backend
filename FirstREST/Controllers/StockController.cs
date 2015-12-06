using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using FirstREST.Lib_Primavera.Model;


namespace FirstREST.Controllers
{
    public class StockController : ApiController
    {
        public ArmazemLoc Get(string id)
        {
            ArmazemLoc ret = Lib_Primavera.PriIntegration.InventoryStock_Get(id);
            if (ret == null)
            {
                throw new HttpResponseException(
                        Request.CreateResponse(HttpStatusCode.NotFound));

            }
            else
            {
                return ret;
            }
        }
    }
}
