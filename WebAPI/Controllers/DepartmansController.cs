using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmansController : ControllerBase
    {
        IDepartmanService _departmanService;

        public DepartmansController(IDepartmanService departmanService)
        {
            _departmanService = departmanService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _departmanService.GetAll();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Departman departman)
        {
            var result = _departmanService.GetAll();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
    }
}
