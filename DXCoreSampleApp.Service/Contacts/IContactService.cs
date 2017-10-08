using DXCoreSampleApp.Common.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DXCoreSampleApp.Service.Contacts
{
    public interface IContactService
    {
        IList<Contact> GetContacts(int tenantId);
        Contact GetContactById(int contactId, int tenantId);
        Contact GetContactByMobile(string mobileNumber, int tenantId);
        Contact GetContactByEmail(string email, int tenantId);
        void AddContact(Contact contact);
        Task AddContactAsync(Contact contact);
        void UpdateContact(Contact contact);
        Task UpdateContactAsync(Contact contact);
        void DeleteContact(Contact contact);
        Task DeleteContactAsync(Contact contact);
    }
}