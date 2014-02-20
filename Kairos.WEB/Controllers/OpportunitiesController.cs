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
    public class OpportunitiesController : ApiControllerBase
    {
        public OpportunitiesController(IDbUnit dbUnit)
        {
            this._dbUnit = dbUnit;
        }

        // GET api/Opportunities
        public IEnumerable<OpportunityDTO> Get()
        {
            //TIP: IN EF 6 you will need to reference EF 6 pacakage from the web project even if you are not using it directly from here
            List<OpportunityDTO> opportunities = new List<OpportunityDTO>();
            _dbUnit.Opportunities.FindAll().OrderByDescending(o => o.Id).ToList().ForEach(o => opportunities.Add(new OpportunityDTO
            {
                Id = o.Id,
                Description = o.Description,
                Client = o.Client,
                Sector = o.Sector,
                PrimaryContact = o.PrimaryContact,
                Telno = o.Telno
            }));
            return opportunities;
        }

        // GET api/Opportunities/5
        public OpportunityDTO Get(int id)
        {
            Opportunity entity = _dbUnit.Opportunities.FindByID(id);
            if (entity == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return new OpportunityDTO
            {
                Id = entity.Id,
                Description = entity.Description,
                Client = entity.Client,
                Sector = entity.Sector,
                PrimaryContact = entity.PrimaryContact,
                Telno = entity.Telno
            };
        }

        // POST api/Opportunities
        public HttpResponseMessage Post([FromBody]OpportunityDTO opp)
        {
            //TIP: Because of ValidationActionFilter, the parameters would have been validated when we reach this point.
            Opportunity newOpportunity = new Opportunity
            {
                Description = opp.Description,
                Client = opp.Client,
                Sector = opp.Sector,
                PrimaryContact = opp.PrimaryContact,
                Telno = opp.Telno
            };

            _dbUnit.Opportunities.Add(newOpportunity);
            try
            {
                _dbUnit.Commit();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError
                    ,ex.Message);
            }
            opp.Id = newOpportunity.Id;
            //TIP: Below two lines as per the http specification to include the id in the header
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, opp);
            response.Headers.Location = new Uri(Url.Link(WebApiConfig.ControllerAndId, new { id = opp.Id}));
            return response;
        }

        // PUT api/Opportunities/5
        public HttpResponseMessage Put(int id, [FromBody]OpportunityDTO opp)
        {
            Opportunity dbOpp = _dbUnit.Opportunities.FindByID(opp.Id);
            if (dbOpp == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            dbOpp.Description = opp.Description;
            dbOpp.Client = opp.Client;
            dbOpp.Sector = opp.Sector;
            dbOpp.PrimaryContact = opp.PrimaryContact;
            dbOpp.Telno = opp.Telno;
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

        // DELETE api/Opportunities/5
        public HttpResponseMessage Delete(int id)
        {
            Opportunity oppToDelete = _dbUnit.Opportunities.FindByID(id);
            if(oppToDelete == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _dbUnit.Opportunities.Remove(oppToDelete);
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