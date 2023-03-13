using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static List<user> heroe = new List<user>
            {
                new user{
                    FirstName="Madhu",
                    LastName="Sharma",
                    Email="m@gmail.com",
                    UserId="ms",
                    Location="Delhi"
                },
                new user{
                    FirstName="Ronak",
                    LastName="Sharma",
                    Email="r@gmail.com",
                    UserId="rs",
                    Location="Delhi"
                }
            };

        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<user>>> Get()
        {

            return Ok(await _context.users.ToListAsync());
        }

        [HttpGet("{UserId}")]
        public async Task<ActionResult<List<user>>> Get(string UserId)
        {
            var hero = await _context.users.FindAsync(UserId);
            if (hero == null)
                return BadRequest("Not Found");
            else
                return Ok(hero);
        }

        [HttpPost]

        public async Task<ActionResult<List<user>>> AddHero(user u)
        {
            _context.users.Add(u);

            await _context.SaveChangesAsync();
            return Ok(await _context.users.ToListAsync());
        }

        [HttpPut]

        public async Task<ActionResult<List<user>>> UpdateHero(user request)
        {
            var dbu = await _context.users.FindAsync(request.UserId);
            if (dbu == null)
                return BadRequest("Not Found");
            else
                dbu.FirstName = request.FirstName;
                dbu.LastName = request.LastName;
                dbu.Email = request.Email;
                dbu.UserId = request.UserId;
                dbu.Location = request.Location;
            await _context.SaveChangesAsync();
            return Ok(await _context.users.ToListAsync());
        }

        [HttpDelete("{UserId}")]
        public async Task<ActionResult<List<user>>> Delete(string UserId)
        {
            var hero = await _context.users.FindAsync(UserId);
            if (hero == null)
                return BadRequest("Not Found");
            else
                _context.users.Remove(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.users.ToListAsync());
        }
    }
}
