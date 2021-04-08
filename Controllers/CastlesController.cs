using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CastlesController : ControllerBase
    {
        private readonly CastlesService _service;
        private readonly KnightsService _knightService;

        public CastlesController(CastlesService service, KnightsService knightsService)
        {
            _service = service;
            _knightService = knightsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Castle>> Get()
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
        public ActionResult<Castle> Get(int id)
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
        public ActionResult<Castle> Create([FromBody] Castle castle)
        {
            try
            {
                return Ok(_service.Create(castle));
            }
            catch (SystemException err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Castle> Edit(int id, [FromBody] Castle castle)
        {
            try
            {
                castle.Id = id;
                return Ok(_service.Edit(id, castle));
            }
            catch (SystemException err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Castle> Delete(int id)
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

        [HttpGet("{id}/knights")]
        public ActionResult<IEnumerable<CastleKnight>> GetKnights(int id)
        {
            try
            {
                return Ok(_knightService.GetByCastle(id));
            }
            catch (SystemException err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}