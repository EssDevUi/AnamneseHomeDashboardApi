using ESS.Amanse.DAL;
using ESS.Amanse.ViewModels;

namespace ESS.Amanse.BLL.ICollection
{
    public interface IPractice
    {
        bool Updateapp_options(app_optionsViewModel Model);
        string AddorUpdate(practice Model);
        practice getPractice(long Id);
        string AddorUpdatepracticedata(practice_dataViewModel Model);
        string AddorUpdatepractice_logo(practice_logoViewModel Model);
        string AddorUpdateapp_options(app_optionsViewModel Model);
        string AddorUpdateanamnesis_pin(anamnesis_pinViewModel Model);
    }
}
