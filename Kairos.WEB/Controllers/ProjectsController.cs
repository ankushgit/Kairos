using Kairos.DAL;
using Kairos.MODEL;
using Kairos.WEB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Kairos.WEB.Controllers
{
    public class ProjectsController : ApiControllerBase
    {
        public ProjectsController(IDbUnit dbUnit)
        {
            this._dbUnit = dbUnit;
        }

        // GET api/Projects
        public IEnumerable<ProjectDTO> Get()
        {
            //TIP: IN EF 6 you will need to reference EF 6 pacakage from the web project even if you are not using it directly from here
            List<ProjectDTO> projects = new List<ProjectDTO>();
            _dbUnit.Projects.FindAll().ToList().ForEach(p => projects.Add(new ProjectDTO
            {
                Id = p.Id,
                Description = p.Description,
                Duration = p.Duration,
                StartDate = p.StartDate,
                EndDate = p.EndDate
            }));
            return projects;
        }
        // GET api/Projects/5
        public ProjectDTO Get(int id)
        {
            Project entity = _dbUnit.Projects.FindByID(id);
            if (entity == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return new ProjectDTO
            {
                Id = entity.Id,
                Description = entity.Description,
                Duration = entity.Duration,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate
            };
        }

        // POST api/Projects
        public HttpResponseMessage Post([FromBody]ProjectDTO prj)
        {
            Project newProject = new Project
            {
                Description = prj.Description,
                Duration = prj.Duration,
                StartDate = prj.StartDate,
                EndDate = prj.EndDate
            };

            _dbUnit.Projects.Add(newProject);
            try
            {
                _dbUnit.Commit();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError
                    , ex.Message);
            }
            prj.Id = newProject.Id;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, prj);
            response.Headers.Location = new Uri(Url.Link(WebApiConfig.ControllerAndId, new { id = prj.Id }));
            return response;
        }

        // PUT api/Projects/5
        public HttpResponseMessage Put(int id, [FromBody]ProjectDTO prj)
        {
            Project dbPrj = _dbUnit.Projects.FindByID(prj.Id);
            if (dbPrj == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            dbPrj.Description = prj.Description;
            dbPrj.Duration = prj.Duration;
            dbPrj.StartDate = prj.StartDate;
            dbPrj.EndDate = prj.EndDate;
            try
            {
                _dbUnit.Commit();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        // DELETE api/Projects/5
        public HttpResponseMessage Delete(int id)
        {
            Project prjToDelete = _dbUnit.Projects.FindByID(id);
            if (prjToDelete == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _dbUnit.Projects.Remove(prjToDelete);
            try
            {
                _dbUnit.Commit();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}