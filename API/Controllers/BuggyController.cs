using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{

    public class BuggyController : BaseAPIController
    {
        private readonly DataContext _context;

        public BuggyController(DataContext dataContext)
        {
            _context = dataContext;
        }


        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {

            return "secret text";

        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {

            var thing = _context.Users.Find(-1);
            if (thing == null) return NotFound();
            return thing;

        }


        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var thing = _context.Users.Find(-1);
            var thingToReturn = thing.ToString();
            return thingToReturn;

        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {

            return BadRequest("This was not good request");

        }

    }
}