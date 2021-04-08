using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KnightsController : ControllerBase
    {
        private readonly KnightsService _service;

        public KnightsController(KnightsService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Knight>> Get()
        {
            try
            {
                return Ok(_service.Get());
            }
            catch (SystemException err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Knight> Get(int id)
        {
            try
            {
                return Ok(_service.Get(id));
            }
            catch (SystemException err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<Knight> Create([FromBody] Knight knight)
        {
            try
            {
                return Ok(_service.Create(knight));
            }
            catch (SystemException err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Knight> Edit(int id, [FromBody] Knight knight)
        {
            try
            {
                knight.Id = id;
                return Ok(_service.Edit(id, knight));
            }
            catch (SystemException err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Knight> Delete(int id)
        {
            try
            {
                return Ok(_service.Delete(id));
            }
            catch (SystemException err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}