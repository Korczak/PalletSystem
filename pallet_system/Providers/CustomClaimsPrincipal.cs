using Microsoft.AspNetCore.Identity;
using pallet_system.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace pallet_system.Providers
{
    /// <summary>
    /// Custom validation of user
    /// </summary>
    public class CustomClaimsPrincipal : ClaimsPrincipal
    {
        private readonly AccountContext context;

        public CustomClaimsPrincipal(AccountContext context)
        {
            this.context = context;
        }

        public override bool IsInRole(string role)
        {
            var currentUser = ClaimsPrincipal.Current.Identity.Name;

            var user = context.WEBUSERS.FirstOrDefault(u => u.EMAIL.Equals(currentUser, StringComparison.CurrentCultureIgnoreCase));

            var roles = from ur in context.WEBUSERINROLES.Where(p => p.WEBUSER_ID == user.WEBUSER_ID)
                        from r in context.WEBROLES
                        where ur.WEBROLE_ID == r.WEBROLE_ID
                        select r.NAME;
            if (user != null)
                return roles.Any(r => r.Equals(role, StringComparison.CurrentCultureIgnoreCase));
            else
                return false;
        }

    }
}
