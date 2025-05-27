using APBDCW11.DTOs;
using APBDCW11.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APBDCW11.Controller;


[Route("api/[controller]")]
[ApiController]
public class PrescriptionController : ControllerBase
{
    
    private readonly IPrescrpitonServicw _prescrpitonServicw;

    public PrescriptionController(IPrescrpitonServicw prescrpitonServicw)
    {
        _prescrpitonServicw = prescrpitonServicw;
    }

    [HttpPost]
    public async Task<IActionResult> AddPrescription(PrescriptionPost prescription)
    {
        await _prescrpitonServicw.PresPOST(prescription);
       // return CreatedA("Prescription", prescription);
       return Created("Pres", prescription);
    }
}