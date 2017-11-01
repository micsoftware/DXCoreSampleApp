using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DXCoreSampleApp.Web.Models.Contacts;
using DXCoreSampleApp.Common.Domain;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using DXCoreSampleApp.Service.Contacts;
using DXCoreSampleApp.Identity;
using Microsoft.AspNetCore.Identity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DXCoreSampleApp.Web.Controllers
{
    [Route("api/contacts")]
    public class ContactController : BaseController
    {       
        private readonly IContactService _contactService;
        private readonly UserManager<ApplicationUser> userManager;

        public ContactController(IContactService contactService,
            UserManager<ApplicationUser> userManager)
        {
            _contactService = contactService;
            this.userManager = userManager;
        }

        [HttpGet("currentuser")]
        public IActionResult GetCurrentUser()
        {
            //var user = userManager.GetUserName
            return Ok(User.Identity);
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            if (string.IsNullOrEmpty(this.TenantId.ToString()))
            {
                return BadRequest();
            }
            var contacts = _contactService.GetContacts(this.TenantId)
                .Select(x => new ContactListModel
                {
                    ContactId = x.Id,
                    Name = x.FirstName + " " + x.LastName,
                    Mobile = x.Mobile,
                    Email = x.Email
                });
            return Ok(contacts);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {            
            var contact = _contactService.GetContactById(id, this.TenantId);

            if (contact == null) return NotFound();

            var model = new ContactModel
            {
                ContactId = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                Mobile = contact.Mobile,
                Age = contact.Age
            };
            return Ok(model);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddContactModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelErrors(ModelState));
            }
            try
            {
                var contact = new Contact
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Mobile = model.Mobile,
                    Email = model.Email,
                    Age = model.Age,
                    TenantId = this.TenantId
                };
                await _contactService.AddContactAsync(contact);
                return Ok(model);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
                
        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UpdateContactModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelErrors(ModelState));
            }

            var contact = _contactService.GetContactById(id, this.TenantId);
            if (contact == null) return NotFound();

            contact.Id = model.ContactId;
            contact.FirstName = model.FirstName;
            contact.LastName = model.LastName;
            contact.Email = model.Email;
            contact.Mobile = model.Mobile;

            _contactService.UpdateContact(contact);
            return Ok(model);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var contact = _contactService.GetContactById(id, this.TenantId);
            if (contact == null) return NotFound();
            await _contactService.DeleteContactAsync(contact);
            return Ok();
        }

        private object GetModelErrors(ModelStateDictionary modelState)
        {
            var errorList = modelState.Values.SelectMany(m => m.Errors)
                                  .Select(e => e.ErrorMessage)
                                  .ToList();
            return errorList;
        }
    }
}
