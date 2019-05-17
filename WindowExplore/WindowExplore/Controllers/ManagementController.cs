
namespace WindowExplore.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using Interfaces;

    [EnableCors("http://localhost:5000", "*", "*")]
    public class ManagementController : ApiController
    {
        private readonly IManagementService service;

        public ManagementController(IManagementService ManagementService)
        {
            service = ManagementService;
        }

        // GET api/Management
        [HttpGet]
        public HttpResponseMessage LoadTable()
        {
            var table = service.GetAllFiles();

            if (table==null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, " No content");
            }

            var message = Request.CreateResponse(HttpStatusCode.OK, table);

            return message;
        }

        // DELETE api/Management/5
        [HttpDelete]
        public HttpResponseMessage DeleteFile(string path)
        {
            bool success = service.RemoveFile(path);
            if (success)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }

            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    "The File with Path is " + path + " not found to delete");

            return message;
        }
    }
}
