using Dotnet.Teste.Core.Entity;
using Dotnet.Teste.Core.Repository;
using Dotnet.Teste.Core.Service;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Dotnet.Teste.Api.Controllers
{
    [RoutePrefix("api/file")]
    public class FileController : ApiController
    {
        private readonly IOperationRepository _repository;
        private readonly IOperationService _service;

        public FileController(IOperationRepository repository, IOperationService service)
        {
            _repository = repository;
            _service = service;
        }

        [Route("csv/{type}")]
        [HttpGet]
        public HttpResponseMessage GetCsvFile(string type)
        {
            if (Enum.TryParse<FilterType>(type, true, out var parsed))
            {
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = GetData(parsed);
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment"); //attachment will force download
                result.Content.Headers.ContentDisposition.FileName = "RecordExport.csv";

                return result;
            }
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        [Route("excel/{type}")]
        [HttpGet]
        public HttpResponseMessage GetExcelFile(string type)
        {
            if (Enum.TryParse<FilterType>(type, true, out var parsed))
            {
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = GetData(parsed, "\t");
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-excel");
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment"); //attachment will force download
                result.Content.Headers.ContentDisposition.FileName = "RecordExport.xls";

                return result;
            }
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        private StringContent GetData(FilterType groupBy, string separator = ",")
        {
            return new StringContent(_service.GetData(groupBy, separator));
        }

    }
}
