using System;
using System.Collections.Generic;
using System.Text;

namespace ESS.Amanse.ViewModels
{
    public class AuthData
    {
        public string Token { get; set; }
        public long TokenExpirationTime { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsResetPwd { get; set; }
    }
}
