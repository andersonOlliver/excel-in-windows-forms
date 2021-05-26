using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dotnet.Teste.Core.Entity;
using Dotnet.Teste.Core.Repository;

namespace Dotnet.Teste.Api.Controllers
{
    public class DataController : ApiController
    {
        private readonly OperationRepository _repository = new OperationRepository();

        public HttpResponseMessage GetAll()
        {
            try
            {

                return Request.CreateResponse(HttpStatusCode.OK, _repository.list());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
        }

    }
}
