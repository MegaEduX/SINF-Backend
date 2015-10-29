using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstREST.Controllers
{
    public class WarehousesController : ApiController
    {
        // GET api/Warehouses
        public IEnumerable<Lib_Primavera.Model.Armazem> Get()
        {
            IEnumerable<Lib_Primavera.Model.Armazem> ret = Lib_Primavera.PriIntegration.Warehouses_List();
            return ret;
        }

        // GET api/Warehouses/A1
        public List<Lib_Primavera.Model.ArmazemLoc> Get(string id)
        {
            List<Lib_Primavera.Model.ArmazemLoc> ret = Lib_Primavera.PriIntegration.WarehousesLocation_Get(id);
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

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

    }
}