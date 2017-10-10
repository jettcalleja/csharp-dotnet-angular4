using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using System.Linq;
using System.Web;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserModel userModel;

        public UserController()
        {
            userModel = new UserModel();
        }    

        [HttpGet]
        public IEnumerable<UserItem> GetAll()
        {
            return userModel.GetAll();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var user = userModel
                .GetByUsernamePassword(item);

            if (user == null) {
                return NotFound();
            }

            return new ObjectResult(user);
        }

        [HttpGet("{id}", Name = "GetUser")]
        public UserItem GetById(int id)
        {
            return userModel.GetByID(id);
        }   

        [HttpPost]
        public IActionResult Create([FromBody] UserItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            userModel.Add(item);

            return CreatedAtRoute("GetUser", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UserItem item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var user = userModel.GetByID(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Email     = item.Email;
            user.Firstname = item.Firstname;
            user.Lastname  = item.Lastname;
            user.Password  = item.Password;

            userModel.Update(user);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = userModel.GetByID(id);
            if (user == null)
            {
                return NotFound();
            }

            userModel.Delete(id);
            return new NoContentResult();
        }
    }
}