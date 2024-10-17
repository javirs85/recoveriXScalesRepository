using DataBaseConnector;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace rXCompanionApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DataController: ControllerBase
{
	private readonly DataBase _context;

	public DataController(DataBase context) 
	{
		_context = context;
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetData(int id)
	{
		var data = "{result: this is a test for "+id.ToString()+"}";
		if (data == null)
			return NotFound();

		return Ok(data);
	}
}
