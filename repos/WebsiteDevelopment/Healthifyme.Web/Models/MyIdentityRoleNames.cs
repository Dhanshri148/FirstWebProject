using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Healthifyme.Web.Models
{
    public enum MyIdentityRoleNames
    {
        [Display(Name = "Admin Role")]
        AppAdmin,

        [Display(Name = "AppDietition")]
        AppDietition,

        [Display(Name = "User Role")]
        AppUser
    }
}
