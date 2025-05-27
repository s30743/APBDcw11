using APBDCW11.DTOs;

namespace APBDCW11.Service;

public interface IpatientService
{
    Task<PatientGET> getPatient(int patientId);
}