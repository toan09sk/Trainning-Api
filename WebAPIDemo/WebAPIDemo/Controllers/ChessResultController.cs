using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPIDemo.BasicAuthentication;
using WebAPIDemo.DTO;
using WebAPIDemo.Interfaces;

namespace WebAPIDemo.Controllers
{
    [EnableCors("http://localhost:4200", "*", "*")]
    [RoutePrefix("api/students")]
    public class ChessResultController : ApiController
    {
        private readonly ITournamentService repository;
        public ChessResultController(ITournamentService service)
        {
            repository = service;
        }

        //[DisableCors]
        // GET api/values
        // HTTP VERB
        [HttpGet]
        public IEnumerable<Tournament> LoadTournaments()
        {
            return repository.GetTournament();
        }


        // GET api/values/5
        // HTTP VERB
        [HttpGet]
        [BasicAuthentication]
        public HttpResponseMessage LoadTournamentById(int id)
        {
            string username = Thread.CurrentPrincipal.Identity.Name;

            if (username == "ross")
            {
                var tournament = repository.FindTournamentById(id);
                if (tournament != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, tournament);//200
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,//404
                        "Tournament with Id " + id.ToString() + " not found");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }


        }

        // POST api/values
        // HTTP VERB
        [HttpPost]
        public HttpResponseMessage InsertTournament([FromBody]Tournament tournament)
        {
            try
            {
                var tournaments = repository.InsertTournament(tournament);
                var message = Request.CreateResponse(HttpStatusCode.Created, tournaments);//201
                message.Headers.Location = new Uri(Request.RequestUri + "/" + tournament.Id.ToString());
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);

            }
        }

        // PUT api/values/5
        // HTTP VERB
        [HttpPut]
        public HttpResponseMessage UpdateTournament(int id, [FromBody]Tournament tournament)
        {
            try
            {
                var entity = repository.FindTournamentById(id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Tourament with Id " + id.ToString() + " not found to update");
                }
                else
                {
                    repository.UpdateTournament(id, tournament);
                    return Request.CreateResponse(HttpStatusCode.OK, tournament);
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE api/values/5
        // HTTP VERB
        [HttpDelete]
        public HttpResponseMessage RemoveTournament(int id)
        {
            try
            {
                var tournament = repository.FindTournamentById(id);
                if (tournament == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "Employee with Id = " + id.ToString() + " not found to delete");
                }
                else
                {
                    repository.DeleteTournament(id);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        static List<Student> students = new List<Student>()
        {
            new Student() { Id = 1, Name = "Tom" },
            new Student() { Id = 2, Name = "Sam" },
            new Student() { Id = 3, Name = "John" }
        };

        [Route("api/Student/{id:int:min(1):max(3)}/courses")]
        public IEnumerable<string> GetStudentCourse(int id)
        {
            if (id == 1)
                return new List<string>() { "C#", "ASP.NET", "SQL Server" };
            else if (id == 2)
                return new List<string>() { "ASP.NET Web API", "C#", "SQL Server" };
            else
                return new List<string>() { "Bootstrap", "jQuery", "AngularJs" };
        }

        [Route("")]
        public IEnumerable<Student> Get()
        {
            return students;
        }

        [Route("{id:int:min(1):max(3)}")]
        public Student Get(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        [Route("{id:int:min(1):max(3)}/courses")]
        public IEnumerable<string> GetStudentCourses(int id)
        {
            if (id == 1)
                return new List<string>() { "C#", "ASP.NET", "SQL Server" };
            else if (id == 2)
                return new List<string>() { "ASP.NET Web API", "C#", "SQL Server" };
            else
                return new List<string>() { "Bootstrap", "jQuery", "AngularJs" };
        }

        [Route("~/api/teachers")]
        public IEnumerable<Teacher> GetTeachers()
        {
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher() { Id = 1, Name = "Rob" },
                new Teacher() { Id = 2, Name = "Mike" },
                new Teacher() { Id = 3, Name = "Mary" }
            };

            return teachers;
        }


    }
}
