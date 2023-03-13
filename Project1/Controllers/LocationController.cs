using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1;
using Location;

namespace Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
            public static List<location> heroes = new List<location>
            {
                new location{
                    locationname="kirti nagar",
                    state="Delhi",
                    city="New Delhi",
                    Zip=110007
                },
                new location{
                    locationname="kamla nagar",
                    state="Delhi",
                    city="New Delhi",
                    Zip=110008
                }
            };

            private readonly DataContext _con;
            public LocationController(DataContext con)
            {
                _con = con;
            }

            [HttpGet]

            public async Task<ActionResult<List<location>>> Get()
            {

                return Ok(await _con.locations.ToListAsync());
            }

            [HttpGet("{locationname}")]
            public async Task<ActionResult<List<location>>> Get(string locationname)
            {
                var loc = await _con.locations.FindAsync(locationname);
                if (loc == null)
                    return BadRequest("Not Found");
                else
                    return Ok(loc);
            }

            [HttpPost]

            public async Task<ActionResult<List<location>>> AddHero(location loc)
            {
                _con.locations.Add(loc);

                await _con.SaveChangesAsync();
                return Ok(await _con.locations.ToListAsync());
            }

            [HttpPut]

            public async Task<ActionResult<List<location>>> UpdateHero(location request)
            {
                var dbloc = await _con.locations.FindAsync(request.locationname);
                if (dbloc == null)
                    return BadRequest("Not Found");
                else
                    dbloc.locationname = request.locationname;
                    dbloc.state = request.state;
                    dbloc.city = request.city;
                    dbloc.Zip = request.Zip;
                await _con.SaveChangesAsync();
                return Ok(await _con.locations.ToListAsync());
            }

            [HttpDelete("{locationname}")]
            public async Task<ActionResult<List<location>>> Delete(string locationname)
            {
                var loc = await _con.locations.FindAsync(locationname);
                if (loc == null)
                    return BadRequest("Not Found");
                else
                    _con.locations.Remove(loc);
                await _con.SaveChangesAsync();
                return Ok(await _con.locations.ToListAsync());
            }
        }
}
