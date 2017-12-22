using NTier.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Web.Http.Controllers;
using NTier.Service.Option;
using System.Web.Mvc;

namespace YMS5122_NTier.UI.Attributes
{
    //Auth işlemlerinin Enum ile gerçekleşebilmesi için bu sınıfı kullanıyoruz.
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class,Inherited =true,AllowMultiple =true)]//Allow multiple ile birden çok rol kuralı belirtilebilir.
    public class AllowAuthorizedAttribute:AuthorizeAttribute
    {
       //String dizi rolleri saklamak için.
        private string[] UserProfilesRequired { get; set; }

        public AllowAuthorizedAttribute(params object[] userProfilesRequired)
        {
            //Enum tipinde gelmediyse
            if (userProfilesRequired.Any(p=>p.GetType().BaseType!=typeof(Enum)))
            {
                throw new ArgumentException("userProfilesRequired");
            }

            this.UserProfilesRequired = userProfilesRequired.Select(p => Enum.GetName(p.GetType(), p)).ToArray();

        }

        //Auth yapma aşamasında bu metot çalışacak
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool authorized = false;

            AppUserService service = new AppUserService();
            //FormsAuth içerisine atılan username httpcontext ile yakalanır.
            AppUser user = service.FindByUserName(HttpContext.Current.User.Identity.Name);

            //Kullanıcının rolü yakalanır.
            string userRole = Enum.GetName(typeof(Role), user.Role);

            //Kullanıcı belirtilen rollerden birine uyuyorsa devam edebilir.
            foreach (var role in this.UserProfilesRequired)
            {
                if (userRole==role)
                {
                    authorized = true;
                    break;
                }
            }

            //Eğer rol kabul edilen roller ile uyuşmuyorsa hata sayfasına yönlendir.
            if (!authorized)
            {
                var url = new UrlHelper(filterContext.RequestContext);
                var logonUrl = url.Action("Http", "Error", new { Id = 401, Area = "" });
                filterContext.Result = new RedirectResult(logonUrl);
            }

        }




    }
}