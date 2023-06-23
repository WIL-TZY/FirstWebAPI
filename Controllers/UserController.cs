/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
*/
using FirstWebAPI.Model;
using FirstWebAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [ApiController]
    // The path will show up as: https://localhost:7040/api/User
    [Route("api/[controller]")]

    // Importing ControllerBase from Microsoft.AspNetCore.Mvc
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        // Using an injection instead of the next block of code
        public UserController(IUserRepository repository) // Type 'ctor' and press TAB to generate the constructor
        {
            // Could also be written as: this.repository
            _repository = repository;
        }


        /*
        (This was just an example for testing)       
        private static List<User> Users()
        {
            return new List<User>{
                new User{
                    Id = 1,
                    Name = "Fulano",
                    BirthDate = new DateTime(1998, 08, 10)
                }
            };
        }
        */

        // Get method
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Returning a status code
            // With the information passed in the static class Users()
            // Can download it in .JSON format using /swagger

            // Calling SearchUsers() from repository inside the Get method
            var users = await _repository.SearchUsers();

            return users.Any() //return Ok(Users());
            ? Ok(users)
            : NoContent();
        }

        // Get method (Id search)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Calling SearchUser() from repository inside GetById method
            var user = await _repository.SearchUser(id);

            return user != null //return Ok(Users());
            ? Ok(user)
            : NotFound("User not found.");
        }

        // Post method
        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            _repository.AddUser(user); // 'user' is an object
            return await _repository.SaveChangesAsync()
            ? Ok("User was succesfully added.")
            : BadRequest("Bad Request. User was not added.");
            /*
            var users = Users();
            users.Add(user);
            // Creating a variable to store the information gotten from Get()
            return Ok(users);
            */
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, User user)
        {
            var userDb = await _repository.SearchUser(id);
            if (userDb == null) return NotFound("User not found.");
            // '??' means 'if value on the left side is not null, then assign the value on the right to it'
            userDb.Name = user.Name ?? userDb.Name;
            // Checking if the BirthDate isn't empty by comparing it to DateTime()
            userDb.BirthDate = user.BirthDate != new DateTime()
            ? user.BirthDate : userDb.BirthDate;

            _repository.UpdateUser(userDb);

            return await _repository.SaveChangesAsync()
                ? Ok("User was succesfully updated.")
                : BadRequest("Bad Request. User was not updated.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userDb = await _repository.SearchUser(id);
            if (userDb == null) return NotFound("User not found.");

            _repository.DeleteUser(userDb);

            return await _repository.SaveChangesAsync()
                ? Ok("User was succesfully deleted.")
                : BadRequest("Bad Request. User was not deleted.");
        }
    }
}
