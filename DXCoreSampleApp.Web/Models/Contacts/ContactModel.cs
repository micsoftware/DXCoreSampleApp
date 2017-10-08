using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DXCoreSampleApp.Web.Models.Contacts
{
    public class ContactModel
    {
        public int ContactId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }
        public int Age { get; set; }
    }
}
