using ESS.Amanse.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESS.Amanse.BLL.ICollection
{
    public interface IAuthService
    {
        //string HashPassword(string password);
        //bool VerifyPassword(string actualPassword, string hashedPassword);
        AuthData GetAuthData(string id, string username);
    }
}
