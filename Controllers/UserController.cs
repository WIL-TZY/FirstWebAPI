/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
*/
using FirstWebAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [ApiController]
    // The path will show up as: https://localhost:7040/api/User
    [Route("api/[controller]")]

    // Importing ControllerBase from Microsoft.AspNetCore.Mvc
    public class UserController : ControllerBase
    {
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

        // Get method
        [HttpGet]
        public IActionResult Get()
        {
            // Returning a status code
            // With the information passed in the static class Users()
            // Can download it in .JSON format using /swagger
            return Ok(Users());
        }

        // Post method
        [HttpPost]
        public IActionResult Post(User user)
        {
            var users = Users();
            users.Add(user);
            // Creating a variable to store the information gotten from Get()
            return Ok(users);
        }
    }
}
