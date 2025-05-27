using APBDCW11.Dal;
using APBDCW11.DTOs;
using APBDCW11.Models;

namespace APBDCW11.Service;

public class PrescriptionService : IPrescrpitonServicw
{
    private readonly DatabaseContext _context;

    public PrescriptionService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task PresPOST(PrescriptionPost prescription)
    {
        var patient = new Patient
        {
            FirstName = prescription.Patient.FirstName,
            LastName = prescription.Patient.LastName,
            Birthdate = prescription.Patient.Birthdate
        };
        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();

        var newPrescription = new Prescription
        {
            IdPatient = patient.IdPatient,
            IdDoctor = prescription.IdDoctor,
            DueDate = prescription.DueDate,
            Date = prescription.Date
        };
        _context.Prescriptions.Add(newPrescription);
        await _context.SaveChangesAsync();

        var newPrescriptionMedicaments = new List<PrescriptionMedicament>();

        foreach (var medicamentDto in prescription.Medicaments)
        {
            newPrescriptionMedicaments.Add(new PrescriptionMedicament()
            {
                IdMedicament = medicamentDto.IdMedicament,
                IdPrescription = newPrescription.IdPrescription,
                Dose = medicamentDto.Dose,
                Details = medicamentDto.Description
            });
        }

        await _context.PrescriptionMedicaments.AddRangeAsync(newPrescriptionMedicaments);
        await _context.SaveChangesAsync();

    }
}