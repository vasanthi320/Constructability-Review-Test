using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace ConstructabilityReviewTest.Models
{
    public static class Helper
    {
        public static string GetFullName(this IIdentity id)
        {
            if (id == null) return null;

            using (var context = new PrincipalContext(ContextType.Domain))
            {
                var userPrincipal = UserPrincipal.FindByIdentity(context, id.Name);
                return userPrincipal != null ? $"{userPrincipal.GivenName} {userPrincipal.Surname}" : null;
            }
        }
        //public static string GetFullName(this IIdentity id)
        //{
        //    var claimsIdentity = id as ClaimsIdentity;

        //    return claimsIdentity == null
        //        ? id.Name
        //        : string.Format("{0} {1}",
        //            claimsIdentity.FindFirst(ClaimTypes.GivenName).Value,
        //            claimsIdentity.FindFirst(ClaimTypes.Surname).Value);
        //}

    }
}
