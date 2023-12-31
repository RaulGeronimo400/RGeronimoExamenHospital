﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoSangreController : ControllerBase
    {
        [EnableCors("API")]
        [HttpGet]
        public IActionResult Get()
        {
            ML.Result result = BL.TipoSangre.GetAll();
            if (result.Correct)
            {
                ML.TipoSangre tipo = new ML.TipoSangre();

                tipo.Tipos = result.Objects;
                return Ok(tipo.Tipos);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
