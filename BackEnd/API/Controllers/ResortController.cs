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
        public ActionResult Update()
        {
            var result = false;
            //var HttpRequest = HttpContext.Current.Request;
            var id = HttpContext.Request.Form["Id"];
            var name = HttpContext.Request.Form["Name"];
            var address = HttpContext.Request.Form["Address"];
            var price = HttpContext.Request.Form["Price"];
            var rating = HttpContext.Request.Form["Rating"];
            var image = HttpContext.Request.Form["Image"];
            try
            {
                var resort = new ResortModel
                {
                    Id = /*id != "" ? Convert.ToInt32(id) : 0*/Convert.ToInt32(id),
                    Name = name,
                    Address = address,
                    Price = price != "" ? Convert.ToInt32(price) : 0,
                    Rating = rating != "" ? Convert.ToInt32(rating) : 0,
                    Image = image
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