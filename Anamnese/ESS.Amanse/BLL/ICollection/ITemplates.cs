using System;
using System.Collections.Generic;
using System.Text;
using ESS.Amanse.DAL;
using ESS.Amanse.ViewModels;
using ESS.Amanse.ViewModels.AnamneseLearningViewModels;
using ESS.Amanse.ViewModels.Vorlagen;

namespace ESS.Amanse.BLL.ICollection
{
    public interface ITemplates
    {
        bool EditTemplateTitleFromeditor(string title, long templateid);
        List<VorlegenForEditHomeLinkViewModel> GetAllTemplatesC12();
        Vorlagen GetTemplateById(long TemplateID);
        string AddtemplateInHomeLink(long templateId, long HomeLinkID);
        string DeleteTemplateFromHomeLink(long id);
        void MoveUp(long id);
        void MoveDown(long id);
        string DeleteHomeLink(long id);
        string Move(int moveFrom, int Moveto);
        List<VorlagenCategory> GetAllTemplatesTypes();
        string CreatenewTemplate(TemplateDuplicateViewModel model);
        List<Vorlagen> getallDocumentTemplates();
        string DeleteTemplates(long id);
        void Duplicate(TemplateDuplicateViewModel model);
        string AddorUpdate(Vorlagen Model);
        List<document_templates> GetTemplateByIdForLearning(List<long> TemplateIDs);
    }
}
