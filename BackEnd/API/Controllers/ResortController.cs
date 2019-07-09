using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BusinessDomain;
using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Dto;

namespace API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ResortController : ControllerBase
    {
        private static readonly IResort _iResort = new ResortManager();

        [HttpGet("api/resort")]
        public ActionResult<List<ResortModel>> Get()
        {
            return _iResort.LoadResort();
        }
    }
}