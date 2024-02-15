using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopBackend.Models;

namespace PetShopBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly petshopContext _context;

        public UserController(petshopContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers() 
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }
        
    }
}
