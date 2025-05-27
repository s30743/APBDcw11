using APBDCW11.DTOs;
using APBDCW11.Service;
using Microsoft.AspNetCore.Mvc;

namespace APBDCW11.Controller;

[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    readonly IpatientService _patientService;
    

    public PatientController(IpatientService patientService)
    {
        _patientService = patientService;
    }


    [HttpGet("{patientId}")]
    public async Task<IActionResult> getPatient(int patientId)
    {
        var res = await _patientService.getPatient(patientId);
        return Ok(res);
    }
}