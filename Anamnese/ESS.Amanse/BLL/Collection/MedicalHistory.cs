using ESS.Amanse.BLL.ICollection;
using ESS.Amanse.BLL.Repo;
using ESS.Amanse.DAL;
using ESS.Amanse.ViewModels;
using Microsoft.EntityFrameworkCore;
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
        public bool CreateMedicalHistroy(string Fname, string Lname, DateTime DOB, string payload, string token)
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
