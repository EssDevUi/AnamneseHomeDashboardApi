using ESS.Amanse.BLL.ICollection;
using ESS.Amanse.BLL.Repo;
using ESS.Amanse.DAL;
using ESS.Amanse.ViewModels;
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
        //public IEnumerable<PatientViewModel> GetAllPatient()
        //{
        //    var List = dbContext.TblPatient.Select(x => new PatientViewModel
        //    {
        //        PatientID = x.PatientId,
        //        MedicalHistoryLink = x.MedicalHistoryLink,
        //        FirstName = x.FirstName,
        //        SurName = x.SurName,
        //        DateOFBirth = x.DateOfbirth.Value.ToShortDateString(),
        //        ReceivedOn=x.ReceivedOn.Value.ToString("MM/dd/yyyy hh:mm tt"),
        //        PatientNumber=x.PatientNumber

        //    }).ToList();
        //    return List;
        //}
    }
}
