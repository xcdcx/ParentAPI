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
        public ActionResult<IEnumerable<PersonResponseDto>> BuildTree(IEnumerable<PersonDto> request)
        {
            try
            {
                IEnumerable<PersonNode> response = _engine.CreateTree(request.ToEntity());
                //return Ok(response);
                return Ok(response.ToDto());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
