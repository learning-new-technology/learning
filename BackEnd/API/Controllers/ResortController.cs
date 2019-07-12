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
            try
            {
                return Ok(_iResort.LoadResort());
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("api/resortdetail/{id}")]
        public ActionResult<ResortModel> ResortDetail(int Id)
        {
            //var id = HttpContext.Request.QueryString["Id"];
            var resort = new ResortModel();
            try
            {
                resort = _iResort.ResortDetail(Id);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok(resort);
        }

        [HttpPost("api/updateresort")]
        public ActionResult Update(ResortUpdateModels reports)
        {
            var result = false;
            try
            {
                var resort = new ResortModel
                {
                    Id = reports.id,
                    Name = reports.name,
                    Address = reports.address,
                    Price = reports.price,
                    Rating = reports.rating,
                    Image = reports.image,
                };
                result = _iResort.UpdateResort(resort);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok(result);
        } 
    }
}