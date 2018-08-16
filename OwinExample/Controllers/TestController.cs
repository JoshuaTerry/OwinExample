using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OwinExample.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("api/v1/TestAdmin")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult TestAdmin()
        {
            return Ok<string>("You are Admin");
        }

        [HttpGet]
        [Route("api/v1/TestGeneral")]
        [Authorize(Roles = "General")]
        public IHttpActionResult TestGeneral()
        {
            return Ok<string>("You are General");
        }

        [HttpGet]
        [Route("api/v1/TestExclusive")]
        [Authorize(Roles = "Exclusive")]
        public IHttpActionResult TestExclusive()
        {
            return Ok<string>("You are Exclusive");
        }
    }
}
