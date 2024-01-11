using Microsoft.AspNetCore.Mvc;
using Raffle.Database;
using Raffle.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly DbConnection _dbConnection;

        public UserController(ILogger<UserController> logger, DbConnection dbConnection)
        {
            _logger = logger;
            _dbConnection = dbConnection;
        }

        [HttpGet(Name = "User")]
        public IActionResult GetUsers()
        {
            try
            {
                var users = _dbConnection.Set<User>().ToList();
                Console.WriteLine(_logger);
                return Ok(users);
            }
            catch (Exception ex) 
            {
                return BadRequest($"Erro ao listar os usuários: {ex.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetUser(int id)
        {
            try
            {
                var user = _dbConnection.Set<User>().Find(id);

                if (user == null)
                {
                    return NotFound($"Usuário com ID {id} não encontrado.");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao obter o usuário: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User newUser) 
        {
            try 
            {
                _dbConnection.User.Add(newUser);
                _dbConnection.SaveChanges();
                return Ok(newUser);
            }
            catch (Exception ex) 
            {
                return BadRequest($"Erro ao criar o usuário: {ex.Message}");
            }
        }

        [HttpPut("{id}", Name = "UpdatedUser")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            try
            {
                var existingUser = _dbConnection.Set<User>().Find(id);

                if (existingUser == null)
                {
                    return NotFound($"Usuário com ID {id} não encontrado.");
                }

                existingUser.Name = updatedUser.Name;
                existingUser.Email = updatedUser.Email;
                existingUser.Password = updatedUser.Password;
                existingUser.UpdatedAt = updatedUser.UpdatedAt;

                _dbConnection.SaveChanges();

                return Ok(existingUser);
            }
            catch (Exception ex) 
            {
                return BadRequest($"Erro ao atualizar o usuário: {ex.Message}");
            
            }
        
        }

        [HttpDelete("{id}", Name = "DeletedUser")]
        public IActionResult DeleteUser(int id) 
        {
            try
            {
                var userToDelete = _dbConnection.Set<User>().Find(id);

                if (userToDelete == null)
                {
                    return NotFound($"Usuário com ID {id} não encontrado.");
                }

                _dbConnection.Set<User>().Remove(userToDelete);
                _dbConnection.SaveChanges();

                return Ok($"Usuário com ID {id} removido com sucesso.");
            }

            catch (Exception ex)
            {
                return BadRequest($"Erro ao excluir o usuário: {ex.Message}");
            }


        }

    }
}
