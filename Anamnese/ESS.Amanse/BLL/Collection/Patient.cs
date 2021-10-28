using ESS.Amanse.BLL.ICollection;
using ESS.Amanse.BLL.Repo;
using ESS.Amanse.DAL;
using ESS.Amanse.ViewModels;
using ESS.Amanse.ViewModels.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESS.Amanse.BLL.Collection
{
    public class Patient : Repository<patients>, IPatient
    {
        public Patient(AmanseHomeContext context) : base(context)
        {

        }
        public IEnumerable<PatientViewModel> GetAllPatient()
        {
            var List = dbContext.tblpatients.Select(x => new PatientViewModel
            {
                PatientID = x.Id,
                //MedicalHistoryLink = x.,
                FirstName = x.first_name,
                SurName = x.last_name,
                DateOFBirth = x.date_of_birth.ToShortDateString(),
                ReceivedOn = x.last_submitted_at.ToString("MM/dd/yyyy hh:mm tt"),
                PatientNumber = x.cellular_phone

            }).ToList();
            return List;
        }
        //public long CreatePatientInAnamneseHome(string Fname, string Lname, DateTime DOB)
        //{
        //    patients patient = new patients();
        //    try
        //    {
        //        patient.first_name = Fname;
        //        patient.last_name = Lname;
        //        patient.date_of_birth = DOB;
        //        patient.insured_date_of_birth = DOB;
        //        patient.last_visit = DateTime.Now;
        //        patient.first_displayed_at = DateTime.Now;
        //        patient.last_submitted_at = DateTime.Now;
        //        patient.position = 1;
        //        dbContext.tblpatients.Add(patient);
        //        dbContext.SaveChanges();
        //    }
        //    catch (Exception e)
        //    {

        //        throw;
        //    }
     

        //    return patient.Id;
        //}
    }
}
