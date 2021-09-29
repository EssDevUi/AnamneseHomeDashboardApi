﻿using System;
using System.Collections.Generic;
using System.Text;
using ESS.Amanse.DAL;
using ESS.Amanse.ViewModels;
using ESS.Amanse.ViewModels.Vorlagen;

namespace ESS.Amanse.BLL.ICollection
{
    public interface ITemplates
    {
        List<VorlegenForEditHomeLinkViewModel> GetAllTemplatesC12();
        Vorlagen GetTemplateById(long TemplateID);
        string AddtemplateInHomeLink(long templateId, long HomeLinkID);
        string DeleteTemplateFromHomeLink(long id);
        void MoveUp(long id);
        void MoveDown(long id);
        string Move(int moveFrom, int Moveto);
    }
}