using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESS.Amanse.BLL.ICollection;
using ESS.Amanse.BLL.Repo;
using ESS.Amanse.DAL;
using ESS.Amanse.ViewModels;
using ESS.Amanse.ViewModels.Vorlagen;

namespace ESS.Amanse.BLL.Collection
{
    public class Templates : Repository<Vorlagen>, ITemplates
    {
        public Templates(AmanseHomeContext context) : base(context)
        {
        }
        // For Home Link
        public Vorlagen GetTemplateById(long TemplateID)
        {
            return dbContext.tblVorlagen.Find(TemplateID);
        }

        public List<VorlegenForEditHomeLinkViewModel> GetAllTemplatesC12()
        {
            return dbContext.tblVorlagen.Where(x => x.CategoryID == 1 || x.CategoryID == 2).Select(x => new VorlegenForEditHomeLinkViewModel
            {
                template_category_id = x.CategoryID,
                @default = x.@default,
                id = x.id,
                title = x.templates
            }).ToList();
        }
        public string AddtemplateInHomeLink(long templateId, long HomeLinkID)
        {
            try
            {
                HomeflowTemplates temp = new HomeflowTemplates();
                temp.VorlagenID = templateId;
                temp.anamnesis_at_home_flowID = HomeLinkID;
                dbContext.tblHomeflowTemplates.Add(temp);
                dbContext.SaveChanges();
                return "Template add in to anamnesis_at_home_flows successfully";
            }
            catch (Exception)
            {
                return "error";
            }
        }

        //public IEnumerable<TemplateViewModel> GetAllTemplatesWithType()
        //{
        //    var data=Include(x=>x.TemplateType).Where(x=>x.SheetTypeId==3).OrderBy(x=>x.SortIndex).Select(x => new TemplateViewModel
        //    {
        //        TemplateId = x.TemplateId,
        //        Name = x.TemplateType.TemplateType,
        //        Link = x.TemplateLink,
        //        templates = x.TemplateName,
        //        DSWin = x.Dswins,
        //        EmailToShowInEmail=x.EmailToShowInEmail,
        //        NotificationEmail=x.NotificationEmail,
        //        PhoneToShowinEmail=x.PhoneToShowinEmail
        //    }).ToList();
        //    return data;
        //}
        //public void DeleteTemplate(long id)
        //{

        //    Remove(GetById(id));
        //}
        public string Move(int moveFrom, int Moveto)
        {
            var objmoveFrom = dbContext.tblVorlagen.Where(x => x.SortIndex == moveFrom + 1).FirstOrDefault();
            var objMoveto = dbContext.tblVorlagen.Where(x => x.SortIndex == Moveto + 1).FirstOrDefault();
            objmoveFrom.SortIndex = Moveto + 1;
            objMoveto.SortIndex = moveFrom + 1;
            dbContext.tblVorlagen.Update(objmoveFrom);
            dbContext.tblVorlagen.Update(objMoveto);
            dbContext.SaveChanges();
            return "Row " + moveFrom + " is Move to position " + Moveto + "...";
        }
        public void MoveUp(long id)
        {
            var obj = dbContext.tblVorlagen.Find(id);
            obj.SortIndex = obj.SortIndex - 1;
            dbContext.tblVorlagen.Update(obj);
            dbContext.SaveChanges();

        }
        public void MoveDown(long id)
        {
            var obj = dbContext.tblVorlagen.Find(id);
            obj.SortIndex = obj.SortIndex + 1;
            dbContext.tblVorlagen.Update(obj);
            dbContext.SaveChanges();
        }
        ////For Sheets Template
        //public IEnumerable<TblTemplate> GetTemplateSheets()
        //{
        //    return Get().Where(x => x.SheetTypeId == 1 || x.SheetTypeId == 2);
        //}
        // //For Delete Sheets Template
        public string DeleteTemplateFromHomeLink(long id)
        {
            try
            {
                dbContext.tblHomeflowTemplates.Remove(dbContext.tblHomeflowTemplates.Find(id));
                dbContext.SaveChanges();
                return "Template remove from link successfully...";
            }
            catch (Exception)
            {
                return "error";
            }
        }
        public string DeleteHomeLink(long id)
        {
            try
            {
                dbContext.tblanamnesis_at_home_flow.Remove(dbContext.tblanamnesis_at_home_flow.Find(id));
                dbContext.SaveChanges();
                return "Template remove successfully...";
            }
            catch (Exception)
            {
                return "error";
            }
        }
        public List<VorlagenCategory> GetAllTemplatesTypes()
        {
            return dbContext.tblVorlagenCategory.ToList();
        }
        public void Duplicate(TemplateDuplicateViewModel model)
        {
            var obj = dbContext.tblVorlagen.Find(model.document_template.id);
            
            Vorlagen template = new Vorlagen();
            template.CategoryID = model.document_template.template_category_id;
            template.templates = model.document_template.title;
            template.languages = obj.languages;
            template.SortIndex = obj.SortIndex+1;
            template.atn_v2 = obj.atn_v2;
            dbContext.tblVorlagen.Add(template);
            dbContext.SaveChanges();
        }
        public string CreatenewTemplate(TemplateDuplicateViewModel model)
        {
            if (model.document_template.id > 0)
            {
                var obj = dbContext.tblVorlagen.Find(model.document_template.id);
                obj.CategoryID = model.document_template.template_category_id;
                obj.templates = model.document_template.title;
                dbContext.tblVorlagen.Update(obj);
                dbContext.SaveChanges();
                return "Template Update Successfully...";
            }
            else
            {
                Vorlagen template = new Vorlagen();
                template.CategoryID = model.document_template.template_category_id;
                template.templates = model.document_template.title;
                dbContext.tblVorlagen.Add(template);
                dbContext.SaveChanges();
                return "Template Created Successfully...";
            }

        }
        public bool EditTemplateTitleFromeditor(string title,long templateid)
        {
            try
            {
                var obj = dbContext.tblVorlagen.Find(templateid);
                obj.templates = title;
                dbContext.tblVorlagen.Update(obj);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
                
        }
        public List<Vorlagen> getallDocumentTemplates()
        {
            return dbContext.tblVorlagen.ToList();
        }
        public string DeleteTemplates(long id)
        {
            dbContext.tblVorlagen.Remove(dbContext.tblVorlagen.Find(id));
            dbContext.SaveChanges();
            return "Template Deleete Successfully...";
        }
        public string AddorUpdate(Vorlagen Model)
        {
            try
            {
                string msg = string.Empty;
                if (Model.id > 0)
                {
                    var oldDocumentTemplates = Find(x => x.id == Model.id);
                    if (oldDocumentTemplates != null)
                    {
                        oldDocumentTemplates.languages = Model.languages;
                        oldDocumentTemplates.atn_v2 = Model.atn_v2;
                        Update(oldDocumentTemplates);
                        msg = "Update";
                    }
                    else
                    {
                        msg = "Not Found";
                    }

                }
                Save();
                return msg;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

    }
}
