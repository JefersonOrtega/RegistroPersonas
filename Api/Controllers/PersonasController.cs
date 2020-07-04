using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistroPersonas.BLL;
using RegistroPersonas.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        // GET: api/Personas
        [HttpGet]
        public ActionResult<List<Personas>> Get()
        {
            return PersonasBLL.GetPersonas();
        }

    }
}
