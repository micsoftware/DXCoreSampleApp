using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DXCoreSampleApp.Web.Models.Contacts
{
    public class ContactListModel : BaseModel
    {       
        public int ContactId { get; set; }
       
        public string Name { get; set; }
       
        public string Mobile { get; set; }
        
        public string Email { get; set; }

    }
}
