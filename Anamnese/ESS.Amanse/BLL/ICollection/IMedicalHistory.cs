using ESS.Amanse.BLL.Collection;
using ESS.Amanse.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESS.Amanse.BLL.ICollection
{
    public interface IMedicalHistory
    {
        List<MedicalHistoryViewModel> MedicalHistoryList();
        MedicalHistoryViewModel MedicalHistoryById(long id);
        bool AssignPatientToMedicalHistroy(long historyid, long PatientID);
        bool CreateMedicalHistroy(string Fname, string Lname, DateTime DOB, string payload, string token);
    }
}
