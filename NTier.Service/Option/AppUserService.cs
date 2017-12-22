using NTier.Model.Option;
using NTier.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Service.Option
{
    public class AppUserService:ServiceBase<AppUser>
    {
        public bool CheckCredentials(string userName,string password)
        {
            return Any(x => x.UserName == userName && x.Password == password);
        }

        public AppUser FindByUserName(string userName)
        {
            return GetByDefault(x => x.UserName == userName);
        }

    }
}