using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Raffle.Database;
using Raffle.Models;

namespace Raffle.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Raffle1Controller : ControllerBase
    {
        private readonly ILogger<BetController> _logger;
        private readonly DbConnection _dbConnection;

        public Raffle1Controller(ILogger<BetController> logger, DbConnection dbConnection)
        {
            _logger = logger;
            _dbConnection = dbConnection;
        }

        [HttpGet(Name = "Raffle")]
        public IActionResult GetRaffles()
        {
            try
            {
                var raffles = _dbConnection.Set<Raffle1>().ToList();
                Console.WriteLine(_logger);
                return Ok(raffles);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao listar os sorteios: {ex.Message}");
            }
        }
    }
    }
