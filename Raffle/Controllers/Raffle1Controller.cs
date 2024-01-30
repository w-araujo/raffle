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
        private readonly ILogger<Raffle1Controller> _logger;
        private readonly DbConnection _dbConnection;

        public Raffle1Controller(ILogger<Raffle1Controller> logger, DbConnection dbConnection)
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

        [HttpGet("{id}", Name = "GetRaffle")]
        public IActionResult GetRaffle(int id)
        {
            try
            {
                var raffle = _dbConnection.Set<Raffle1>().Find(id);

                if (raffle == null)
                {
                    return NotFound($"O sorteio com ID {id} não encontrado.");
                }

                return Ok(raffle);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao obter o sorteio: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreateRaffle([FromBody] Raffle1 newRaffle)
        {
            try
            {
                _dbConnection.Raffle1.Add(newRaffle);
                _dbConnection.SaveChanges();
                return Ok(newRaffle);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar o sorteio: {ex.Message}");
            }
        }
    }
    }
