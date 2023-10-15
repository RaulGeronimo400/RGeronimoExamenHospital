using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        [EnableCors("API")]
        [HttpGet]
        public IActionResult Get()
        {
            ML.Result result = BL.Paciente.GetAll();
            if (result.Correct)
            {
                ML.Paciente paciente = new ML.Paciente();

                paciente.Pacientes = result.Objects;
                return Ok(paciente.Pacientes);
            }
            else
            {
                return BadRequest();
            }
        }

        [EnableCors("API")]
        [HttpGet("{IdPaciente}")]
        public IActionResult Get(int IdPaciente)
        {
            ML.Result result = BL.Paciente.GetById(IdPaciente);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [EnableCors("API")]
        [HttpPost]
        public IActionResult Post([FromBody] ML.Paciente paciente)
        {
            ML.Result result = BL.Paciente.Add(paciente);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [EnableCors("API")]
        [HttpPut("{IdPaciente}")]
        public IActionResult Put(int IdPaciente, [FromBody] ML.Paciente paciente)
        {
            paciente.IdPaciente = IdPaciente;
            ML.Result result = BL.Paciente.Update(paciente);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [EnableCors("API")]
        [HttpDelete("{IdPaciente}")]
        public IActionResult Delete(int IdPaciente)
        {
            ML.Result result = BL.Paciente.Delete(IdPaciente);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
