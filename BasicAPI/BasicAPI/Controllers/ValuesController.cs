using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BasicAPI.ViewModels;
using Newtonsoft.Json;

namespace BasicAPI.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        // GET api/values
        [Route("get")]
        public HttpResponseMessage Get()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("First Value", "value1");
            dict.Add("Second Value", "value2");
            
            return Request.CreateResponse(HttpStatusCode.OK, dict);
        }

        // GET api/values/5
        [Route("Get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            if (id <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Id");
            }

            string val = String.Empty;

            switch (id)
            {
                case 1:
                    val = "value1";
                    break;
                case 2:
                    val = "value2";
                    break;
                default:
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Id");
            }

            return Request.CreateResponse(HttpStatusCode.OK, val);
        }

        // POST api/values
        [HttpPost]
        [Route("updatelist")]
        public HttpResponseMessage UpdateList(ValueModel model)
        {
            if (model == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Model cannot be null");
            }

            if (model.Id <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid ID");
            }

            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("First Value", "value1");
            dict.Add("Second Value", "value2");
            dict.Add("Third Value", "value" + model.Id.ToString());

            return Request.CreateResponse(HttpStatusCode.OK, dict);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
