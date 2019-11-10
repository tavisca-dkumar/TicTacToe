using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tic_tac_toe.Models;
using tic_tac_toe.Services;

namespace tic_tac_toe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicTacToeController : ControllerBase
    {
        public GameService service = new GameService();
        // GET: api/TicTacToe
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.GameState());
        }

        // GET: api/TicTacToe/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TicTacToe
        [HttpPost]
        public IActionResult Post([FromBody] Position position)
        {
            var response = service.AddPosition(position);
            if (string.Equals(response, "bad_request"))
                return BadRequest("it's not ur turn");
            else if (string.Equals(response, "can't"))
                return BadRequest("u can't place in this position");
            else
            {
                if (service.IsWin(position.X_Coordinate, position.Y_Coordinate))
                    return Ok("player " + position.PlayerId + " win");
                else if (service.IsLastMove())
                {
                    service.ResetGame();
                    return Ok("tied");
                }

                else
                    return Ok();
            }



        }

        // PUT: api/TicTacToe/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
