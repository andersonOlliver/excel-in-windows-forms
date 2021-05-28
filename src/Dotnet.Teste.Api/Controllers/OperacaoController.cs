using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Dotnet.Teste.Core.Entity;
using Dotnet.Teste.Core.Repository;
using Dotnet.Teste.Core.Service;
using WebApi.OutputCache.V2;

namespace Dotnet.Teste.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/operacao")]
    // [CacheOutput(ClientTimeSpan = 50, ServerTimeSpan = 50)]
    public class OperacaoController : ApiController
    {
        private readonly OperationRepository _repository = new OperationRepository();
        private readonly DataService _service = new DataService();

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

        [Route("{type:int}")]
        [ResponseType(typeof(FilteredDto))]
        public HttpResponseMessage GetGrouped(FilterType type)
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
