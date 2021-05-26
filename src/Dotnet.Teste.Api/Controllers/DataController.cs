using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Dotnet.Teste.Core.Entity;
using Dotnet.Teste.Core.Repository;
using Dotnet.Teste.Core.Service;

namespace Dotnet.Teste.Api.Controllers
{
    public class DataController : ApiController
    {
        private readonly OperationRepository _repository = new OperationRepository();
        private readonly DataService _service = new DataService();

        public async Task<HttpResponseMessage> GetAll()
        {
            try
            {
                var result = await _service.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
        }

        public HttpResponseMessage GetAll([FromUri] FilterType type)
        {
            try
            {
                var result = _repository.GroupedBy(type);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
        }
    }
}
