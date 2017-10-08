using System;
using System.Collections.Generic;
using System.Text;

namespace DXCoreSampleApp.Common.Domain
{
    public class Contact: BaseEntity, ITenant
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int TenantId { get; set; }
    }   
}
