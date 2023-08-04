using API.Dtos;
using Engine;
using Engine.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private readonly IEngine _engine;
        public ParentController(IEngine engine)
        {
            _engine = engine;
        }

        [HttpPost]
        public ActionResult<PersonNode>/*<IEnumerable<PersonResponseDto>>*/ BuildTree(IEnumerable<PersonDto> request)
        {
            try
            {
                var response = _engine.CreateTree(request.ToEntity());
                return Ok(response);
                //return Ok(new List<PersonResponseDto>());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
