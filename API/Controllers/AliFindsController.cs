using Domain;
using Microsoft.AspNetCore.Mvc;
using Application.AliFinds;

namespace API.Controllers
{
    public class AliFindsController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<List<AliFind>>> GetAliFinds() => await Mediator.Send(new List.Query());

        [HttpGet("{id}")]
        [ActionName("GetAliFind")]
        public async Task<ActionResult<AliFind>> GetAliFind(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }

        [HttpPost]
        public async Task<IActionResult> CreateAliFind (AliFind aliFind)
        {
            return Ok(await Mediator.Send(new Create.Command{AliFind = aliFind}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAliFind (Guid id, AliFind aliFind)
        {
            aliFind.Id = id;
            return Ok(await Mediator.Send(new Edit.Command{AliFind = aliFind}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAliFind (Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command{Id = id}));
        }
    }
}