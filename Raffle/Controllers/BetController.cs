using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Raffle.Database;
using Raffle.Models;

namespace Raffle.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class BetController : ControllerBase
        {
            private readonly ILogger<BetController> _logger;
            private readonly DbConnection _dbConnection;

            public BetController(ILogger<BetController> logger, DbConnection dbConnection)
            {
                _logger = logger;
                _dbConnection = dbConnection;
            }

        [HttpGet(Name = "Bet")]
        public IActionResult GetBets()
        {
            try
            {
                var bets = _dbConnection.Set<Bet>().AsNoTracking().Include(b => b.User).ToList();
                return Ok(bets);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao listar as apostas");
                return BadRequest($"Erro ao listar as apostas: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreateBet(int userId, [FromBody] Bet newBet)
        {
            try
            {
                var existingUser = _dbConnection.Set<User>().Find(userId);

                Console.WriteLine(existingUser);
                if (existingUser == null)
                {
                    return NotFound($"Usuário com ID {userId} não encontrado.");
                }

                 newBet.User = existingUser;

                _dbConnection.Bet.Add(newBet);
                _dbConnection.SaveChanges();

                return Ok(newBet);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ero ao criar uma aposta");
                return BadRequest($"Erro ao criar uma aposta: {ex.Message}");
            }
        }


    }
    }
