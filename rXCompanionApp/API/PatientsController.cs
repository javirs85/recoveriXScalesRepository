using DataBaseConnector;
using Microsoft.AspNetCore.Mvc;

namespace rXCompanionApp.API;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
	private readonly DataBase DB;

	public PatientsController(DataBase context)
	{
		DB = context;
	}


	[HttpGet()]
	public async Task<IActionResult> GetAllPatientIDs()
	{
		try
		{
			var patients = await DB.GetPatients();
			var IDs = patients.Select(p => new { PatientLabel = p.PatientLabel.Trim(), Id = p.Id });
			return Ok(IDs);
		}
		catch
		{
			return NotFound();
		}
	}

	[HttpGet("{PatientCode}")]
	public async Task<IActionResult> GetPatientSummary(Guid PatientCode)
	{
		try
		{
			var patient = await DB.GetPatient(PatientCode);
			return Ok(patient);
		}
		catch
		{
			return NotFound("Patient does not exist in the Data Base");
		}
	}

	[HttpGet("{PatientCode}/{TherapyCode}")]
	public async Task<IActionResult> GetPatientTherapySummary(string TherapyCode)
	{
		try
		{
			var result = await DB.sGetAllMeasurementsSummariesOfTherapy(TherapyCode);
			return Ok(result);
		}
		catch
		{
			return NotFound("Patient does not exist in the Data Base");
		}
	}


	[HttpGet("{PatientCode}/{TherapyCode}/{SessionID}")]
	public async Task<IActionResult> GetPatientTherapySummary(Guid SessionID)
	{
		try
		{
			var result = await DB.GetSummarizedSessionResultsForAPI(SessionID);
			return Ok(result);
		}
		catch
		{
			return NotFound("Patient does not exist in the Data Base");
		}
	}
}
