using Dotnet.Teste.Core.Entity;
using Dotnet.Teste.Core.Repository;
using Dotnet.Teste.Core.Service;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Dotnet.Teste.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/operacao")]
    // [CacheOutput(ClientTimeSpan = 50, ServerTimeSpan = 50)]
    public class OperacaoController : ApiController
    {
        private readonly IOperationRepository _repository;
        private readonly IOperationService _service;

        public OperacaoController(IOperationRepository repository, IOperationService service)
        {
            _repository = repository;
            _service = service;
        }

        [Route("")]
        [ResponseType(typeof(List<Operation>))]
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

        [Route("{type}")]
        [ResponseType(typeof(Grouped))]
        public HttpResponseMessage GetGrouped(string type)
        {
            try
            {
                if (Enum.TryParse<FilterType>(type, true, out var parsed))
                {
                    var result = _repository.GroupedBy(parsed);
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }

                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
        }
    }
}
