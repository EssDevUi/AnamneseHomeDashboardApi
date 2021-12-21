using ESS.Amanse.BLL.ICollection;
using ESS.Amanse.BLL.Repo;
using ESS.Amanse.DAL;
using ESS.Amanse.ViewModels;
using ESS.Amanse.ViewModels.AnamneseLearningViewModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESS.Amanse.BLL.Collection
{
    public class MedicalHistory : Repository<ESS.Amanse.DAL.MedicalHistory>, IMedicalHistory
    {
        public MedicalHistory(AmanseHomeContext context) : base(context)
        {

        }
        public List<MedicalHistoryViewModel> MedicalHistoryList()
        {
            return dbContext.tblMedicalHistory.Include(x => x.patient).Select(x => new MedicalHistoryViewModel
            {
                medicalHistoryID = x.id,
                first_name = x.first_name,
                last_name = x.last_name,
                date_of_birth = x.date_of_birth.ToString("dd.MM.yyyy"),
                created_at = x.created_at.ToString("dd.MM.yyyy HH:mm"),
                pvs_patid = x.patient.Id,
            }).ToList();
        }
        public List<DAL.MedicalHistory> MedicalHistoryByPatientId(long patientId)
        {
            return dbContext.tblMedicalHistory.Where(x => x.pvs_patid == patientId).ToList();
        }
        public MedicalHistoryViewModel MedicalHistoryById(long id)
        {
            return dbContext.tblMedicalHistory.Include(x => x.patient).Where(x => x.id == id).Select(x => new MedicalHistoryViewModel
            {
                medicalHistoryID = x.id,
                first_name = x.first_name,
                last_name = x.last_name,
                date_of_birth = x.date_of_birth.ToString("dd.MM.yyyy"),
                created_at = x.created_at.ToString("dd.MM.yyyy HH:mm"),
                pvs_patid = x.patient.Id,
            }).FirstOrDefault();
        }
        public bool DeleteMedicalHistoryById(long id)
        {
            try
            {
                var history = dbContext.tblMedicalHistory.Where(x => x.id == id).FirstOrDefault();
                dbContext.Remove(history);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           
        }
        public DataForSummeryViewModel MedicalHistoryByIdForSummary(long id)
        {
            return dbContext.tblMedicalHistory.Include(x => x.patient).Where(x => x.id == id).Select(x => new DataForSummeryViewModel
            {
                id = x.id,
                token = x.token,
                practice_id = x.practice_id,
                pvs_patid = x.patient.Id,
                created_at = x.created_at,
                submitted_at = x.date_of_birth,
                patient_payload = x.patient,
                payloadJson = x.patient_payload
            }).FirstOrDefault();

        }
        public bool AssignPatientToMedicalHistroy(long historyid, long PatientID)
        {
            try
            {
                var history = dbContext.tblMedicalHistory.Where(x => x.id == historyid).FirstOrDefault();
                history.pvs_patid = PatientID;
                dbContext.tblMedicalHistory.Update(history);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool CreateMedicalHistroy(string Fname, string Lname, DateTime DOB, string payload, string token, bool isdrafted = false)
        {
            ESS.Amanse.DAL.MedicalHistory history = new ESS.Amanse.DAL.MedicalHistory();
            try
            {
                history.patient_payload = payload;
                history.first_name = Fname;
                history.last_name = Lname;
                history.date_of_birth = DOB;
                history.submitted_at = DateTime.Now;
                history.created_at = DateTime.Now;
                history.practice_id = 1;
                history.token = token;
                history.IsInDraft = isdrafted;
                dbContext.tblMedicalHistory.Update(history);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
        public bool CreateMedicalHistroyAnamneseLearning(long PatientID, string Fname, string Lname, string title, DateTime DOB, string payload, string token, bool isdrafted = false)
        {
            ESS.Amanse.DAL.MedicalHistory history = new ESS.Amanse.DAL.MedicalHistory();
            try
            {
                history.patient_payload = payload;
                history.pvs_patid = PatientID;
                history.first_name = Fname;
                history.last_name = Lname;
                history.date_of_birth = DOB;
                history.submitted_at = DateTime.Now;
                history.created_at = DateTime.Now;
                history.practice_id = 1;
                history.token = token;
                history.IsInDraft = isdrafted;
                history.title = title;
                dbContext.tblMedicalHistory.Update(history);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }



        }
    }
}
