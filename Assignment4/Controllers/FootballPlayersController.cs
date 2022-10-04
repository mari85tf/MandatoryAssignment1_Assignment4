using Assignment1;
using Assignment4.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment4.Controllers
{
    [Route("footballplayers")]
    [ApiController]
    public class FootballPlayersController : ControllerBase
    {
            
            private readonly FootballPlayersManager _manager = new FootballPlayersManager();

            [HttpGet]
            public IEnumerable<FootballPlayer> Get()
            {
                return _manager.GetAll();
            }

            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [HttpGet("{id}")]
            public ActionResult<FootballPlayer> Get(int id)
            {
                FootballPlayer player = _manager.GetById(id);
            if (player == null) return NotFound("No such player, id: " + id);
                return Ok(player);
            }

            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [HttpPost]
            public ActionResult<FootballPlayer> Post([FromBody] FootballPlayer value)
            {
                FootballPlayer player = _manager.Add(value);
                if (player == null) return NotFound("No such player, id: " + player.Id);
                return Created("api/[controller]",player);
            }

            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [HttpPut("{id}")]
            public ActionResult<FootballPlayer> Put(int id, [FromBody] FootballPlayer value)
            {
                FootballPlayer player = _manager.Update(id, value);
                if (player == null) return NotFound("No such player, id: " + id);
                return Ok(player);
            }

            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [HttpDelete("{id}")]
            public ActionResult<FootballPlayer> Delete(int id)
            {
                FootballPlayer player = _manager.Delete(id);
                if (player == null) return NotFound("No such player, id: " + id);
                return Ok(player);
            }
    }
    
}
