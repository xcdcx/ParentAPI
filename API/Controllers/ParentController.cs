﻿using API.Dtos;
using Engine.Engines;
using Engine.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Entities;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IParentEngine _engine;
        public ParentController(ILogger<ParentController> logger, IParentEngine engine)
        {
            _logger = logger;
            _engine = engine;
        }

        /// <summary>
        /// Belongs child to parents objects
        /// </summary>
        /// <param name="request"></param>
        /// <returns>parent - child tree</returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        [HttpPost]
        public ActionResult<IEnumerable<PersonResponseDto>> BuildTree(IEnumerable<PersonDto> request)
        {
            IEnumerable<PersonResponseDto> result = new List<PersonResponseDto>();
            try
            {
                Node response = _engine.CreateTree(request.ToEntity());
                result = response.ToDto();
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message, "Duplicate id in input");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            return Ok(result);
        }
    }
}
