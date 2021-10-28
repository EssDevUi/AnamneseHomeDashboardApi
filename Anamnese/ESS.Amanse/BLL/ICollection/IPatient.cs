using ESS.Amanse.DAL;
using ESS.Amanse.ViewModels;
using ESS.Amanse.ViewModels.Patient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESS.Amanse.BLL.ICollection
{
    public interface IPatient
    {
        IEnumerable<PatientViewModel> GetAllPatient();
        //long CreatePatientInAnamneseHome(string Fname, string Lname, DateTime DOB);
    }
}
