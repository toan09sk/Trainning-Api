using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using UploadFile.Models;

namespace UploadFile.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
    public class UploadFileController : ApiController
    {
        [HttpPost]
        public void UploadFile()
        {
            if (HttpContext.Current.Request.Files.Count > 0)
            {
                try
                {
                    foreach (var fileName in HttpContext.Current.Request.Files.AllKeys)
                    {
                        HttpPostedFile file = HttpContext.Current.Request.Files[fileName];
                        if (file != null)
                        {

                            FileDTO fileDTO = new FileDTO();

                            fileDTO.FileActualName = file.FileName;
                            fileDTO.FileExt = Path.GetExtension(file.FileName);
                            fileDTO.ContentType = file.ContentType;

                            //Generate a unique name using Guid
                            fileDTO.FileUniqueName = Guid.NewGuid().ToString();

                            //Get physical path of our folder where we want to save images
                            var rootPath = HttpContext.Current.Server.MapPath("~/UploadedFiles");

                            var fileSavePath = System.IO.Path.Combine(rootPath, fileDTO.FileUniqueName + fileDTO.FileExt);

                            // Save the uploaded file to "UploadedFiles" folder
                            file.SaveAs(fileSavePath);

                            //Save File Meta data in Database

                            DummyDAL.SaveFileInDB(fileDTO);

                        }
                    }//end of foreach
                }
                catch (Exception ex)
                { }
            }//end of if count > 0

            var age = HttpContext.Current.Request["Age"];

        }


        [HttpPost]
        [Route("api/UploadFile/UploadFileTask")]
        public async Task<string> UploadFileTask()
        {
            var ctx = HttpContext.Current;
            var root = ctx.Server.MapPath("~/App_Data");
            var provider =
                new MultipartFormDataStreamProvider(root);

            try
            {
                await Request.Content
                    .ReadAsMultipartAsync(provider);

                foreach (var file in provider.FileData)
                {
                    var name = file.Headers
                        .ContentDisposition
                        .FileName;

                    // remove double quotes from string.
                    name = name.Trim('"');

                    var localFileName = file.LocalFileName;
                    var filePath = Path.Combine(root, name);

                    File.Move(localFileName, filePath);
                }
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            return "File uploaded!";
        }


        [HttpGet]
        public Object DownloadFile(String uniqueName)
        {
            //Physical Path of Root Folder
            var rootPath = System.Web.HttpContext.Current.Server.MapPath("~/UploadedFiles");

            //Find File from DB against unique name
            var fileDTO = DummyDAL.GetFileByUniqueID(uniqueName);

            if (fileDTO != null)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                var fileFullPath = System.IO.Path.Combine(rootPath, fileDTO.FileUniqueName + fileDTO.FileExt);

                byte[] file = System.IO.File.ReadAllBytes(fileFullPath);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(file);

                response.Content = new ByteArrayContent(file);
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                //String mimeType = MimeType.GetMimeType(file); //You may do your hard coding here based on file extension

                response.Content.Headers.ContentType = new MediaTypeHeaderValue(fileDTO.ContentType);// obj.DocumentName.Substring(obj.DocumentName.LastIndexOf(".") + 1, 3);
                response.Content.Headers.ContentDisposition.FileName = fileDTO.FileActualName;
                return response;
            }
            else
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotFound);
                return response;
            }

        }

        // 0) Action Method
        [HttpGet]
        [Route("api/FileDownloading/download")]
        public HttpResponseMessage GetDogPic()
        {
            var result =
                new HttpResponseMessage(HttpStatusCode.OK);

            // 1) Get file bytes
            var fileName = "dogpic.jpg";
            var filePath = HttpContext.Current.Server
                .MapPath($"~/App_Data/{fileName}");

            var fileBytes = File.ReadAllBytes(filePath);

            // 2) Add bytes to a memory stream
            var fileMemStream =
                new MemoryStream(fileBytes);

            // 3) Add memory stream to response
            result.Content = new StreamContent(fileMemStream);

            // 4) build response headers
            var headers = result.Content.Headers;

            headers.ContentDisposition =
                new ContentDispositionHeaderValue("attachment");
            headers.ContentDisposition.FileName = fileName;

            headers.ContentType =
                //new MediaTypeHeaderValue("application/jpg");
                new MediaTypeHeaderValue("application/octet-stream");

            headers.ContentLength = fileMemStream.Length;

            return result;
        }
    }
}
