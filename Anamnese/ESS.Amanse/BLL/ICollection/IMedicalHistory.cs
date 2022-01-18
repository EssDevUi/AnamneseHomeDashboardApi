using ESS.Amanse.BLL.Collection;
using ESS.Amanse.ViewModels;
using ESS.Amanse.ViewModels.AnamneseLearningViewModels;
using ESS.Amanse.ViewModels.Patient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESS.Amanse.BLL.ICollection
{
    public interface IMedicalHistory
    {
        long CreateExistingPatientMedicalHistroy(long PtID, string payload, string token, bool isdrafted = false);
        long CreatePatientMedicalHistroy(Root patient, string payload, string token, bool isdrafted = false);
        List<MedicalHistoryViewModel> MedicalHistoryList();
        MedicalHistoryViewModel MedicalHistoryById(long id);
        bool AssignPatientToMedicalHistroy(long historyid, long PatientID);
        bool CreateMedicalHistroy(string Fname, string Lname, DateTime DOB, string payload, string token, bool isdrafted = false);
        DataForSummeryViewModel MedicalHistoryByIdForSummary(long id);
        bool CreateMedicalHistroyAnamneseLearning(long PatientID, string Fname, string Lname, string title, DateTime DOB, string payload, string token, bool isdrafted = false);
        List<DAL.MedicalHistory> MedicalHistoryByPatientId(long patientId);
        bool DeleteMedicalHistoryById(long id);
    }
}
