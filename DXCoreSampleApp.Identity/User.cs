using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DXCoreSampleApp.Identity
{
    public class ApplicationUser: IdentityUser<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsSubscriber { get; set; }
    }
}
