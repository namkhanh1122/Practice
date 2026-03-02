using Microsoft.AspNetCore.Mvc;
using Data;
using Entities;
using Data.DTOs;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserControllers : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserControllers(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserReq createUserReq)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new User
            {
                userId = Guid.NewGuid(),
                userName = createUserReq.userName,
                email = createUserReq.email,
                password = createUserReq.password
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPatch("{id}")]
        public IActionResult UpdateUser (Guid id, UpdateUserReq updateUserReq)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            user.userName = updateUserReq.userName;
            user.email = updateUserReq.email;
            _context.SaveChanges();
            return NoContent();
        }
    }
}