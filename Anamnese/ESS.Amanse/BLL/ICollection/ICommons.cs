using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ESS.Amanse.BLL.ICollection
{
    public interface ICommons
    {
        string UploadedFile(IFormFile ProfileImage);
        string GetCookie(string key);
        void RemoveCookie(string key);
        void SetCookie(string key, string value, int? expireTime);
        string SaveImage(string ImgStr, string ImgName);
       
    }
}
