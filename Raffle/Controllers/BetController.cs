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


        [HttpGet("{id}", Name = "GetBet")]
        public IActionResult GetBet(int id)
        {
            try
            {
                var bet = _dbConnection.Set<Bet>().Include(b => b.User).FirstOrDefault(b => b.Id == id);

                if (bet == null)
                {
                    return NotFound($"Aposta com ID {id} não encontrada.");
                }

                return Ok(bet);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao obter a aposta: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreateBet(int userId, int raffleId, [FromBody] Bet newBet)
        {
            try
            {
                var existingUser = _dbConnection.Set<User>().Find(userId);

                if (existingUser == null)
                {
                    return NotFound($"Usuário com ID {userId} não encontrado.");
                }

                var existingRaffle = _dbConnection.Set<Raffle1>().Find(raffleId);

                if (existingRaffle == null)
                {
                    return NotFound($"Sorteio com ID {raffleId} não encontrado.");
                }

                 newBet.User = existingUser;
                 newBet.Raffle1 = existingRaffle;

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

        [HttpDelete("{id}", Name = "DeletedBet")]
        public IActionResult DeleteBet(int id)
        {
            try
            {
                var betToDelete = _dbConnection.Set<Bet>().Find(id);

                if (betToDelete == null)
                {
                    return NotFound($"Aposta com ID {id} não encontrada.");
                }

                _dbConnection.Set<Bet>().Remove(betToDelete);
                _dbConnection.SaveChanges();

                return Ok($"Aposta com ID {id} removida com sucesso.");
            }

            catch (Exception ex)
            {
                return BadRequest($"Erro ao excluir a aposta: {ex.Message}");
            }


        }


    }
    }
