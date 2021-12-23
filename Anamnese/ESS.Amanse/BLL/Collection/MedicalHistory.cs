using ESS.Amanse.BLL.ICollection;
using ESS.Amanse.BLL.Repo;
using ESS.Amanse.DAL;
using ESS.Amanse.ViewModels;
using ESS.Amanse.ViewModels.AnamneseLearningViewModels;
using ESS.Amanse.ViewModels.Patient;
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
        public long CreatePatientMedicalHistroy(Root Pobj, string payload, string token, bool isdrafted = false)
        {
            try
            {
                patients model = new patients();
                model.address1 = Pobj.patient.address1;
                model.address2 = Pobj.patient.address2;
                model.cellular_phone = Pobj.patient.cellular_phone;
                model.city = Pobj.patient.city;
                model.country = Pobj.patient.country;
                model.created_at = DateTime.Now;
                model.date_of_birth = Pobj.patient.date_of_birth;
                model.email = Pobj.patient.email;
                model.fax = Pobj.patient.fax;
                model.first_name = Pobj.patient.first_name;
                model.gender = Pobj.patient.gender;
                model.home_phone = Pobj.patient.home_phone;
                model.insurance_status = Pobj.patient.insurance_status;
                model.insured_address1 = Pobj.patient.insured_address1;
                model.insured_address2 = Pobj.patient.insured_address2;
                model.insured_city = Pobj.patient.insured_city;
                model.insured_country = Pobj.patient.insured_country;
                model.insured_date_of_birth = Pobj.patient.insured_date_of_birth;
                model.insured_first_name = Pobj.patient.insured_first_name;
                model.insured_last_name = Pobj.patient.insured_last_name;
                model.insured_phone = Pobj.patient.insured_phone;
                model.insured_salutation = Pobj.patient.insured_salutation;
                model.insured_title = Pobj.patient.insured_title;
                model.insured_zipcode = Pobj.patient.insured_zipcode;
                model.last_name = Pobj.patient.last_name;
                model.last_submitted_at = DateTime.Now;
                model.salutation = Pobj.patient.salutation;
                model.title = Pobj.patient.title;
                model.zipcode = Pobj.patient.zipcode;

                dbContext.tblpatients.Add(model);
                dbContext.SaveChanges();


                ESS.Amanse.DAL.MedicalHistory history = new ESS.Amanse.DAL.MedicalHistory();

                history.patient_payload = payload;
                history.first_name = Pobj.patient.first_name;
                history.last_name = Pobj.patient.last_name;
                history.date_of_birth = Pobj.patient.date_of_birth;
                history.submitted_at = DateTime.Now;
                history.created_at = DateTime.Now;
                history.practice_id = 1;
                history.token = token;
                history.IsInDraft = isdrafted;
                history.pvs_patid = model.Id;
                dbContext.tblMedicalHistory.Update(history);
                dbContext.SaveChanges();


                return model.Id;
            }
            catch (Exception e)
            {

                return 0;
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
