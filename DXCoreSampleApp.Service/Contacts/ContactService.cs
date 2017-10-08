using System;
using System.Collections.Generic;
using DXCoreSampleApp.Common.Domain;
using DXCoreSampleApp.Common.Data;
using System.Threading.Tasks;
using System.Linq;

namespace DXCoreSampleApp.Service.Contacts
{
    public class ContactService: IContactService
    {
        private readonly IRepository<Contact> _contactRepository; 
        public ContactService(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public void AddContact(Contact contact)
        {
            _contactRepository.Insert(contact);
        }

        public async Task AddContactAsync(Contact contact)
        {
            await _contactRepository.InsertAsync(contact);
        }

        public void DeleteContact(Contact contact)
        {
            _contactRepository.Delete(contact);
        }

        public async Task DeleteContactAsync(Contact contact)
        {
            await _contactRepository.DeleteAsync(contact);
        }

        public Contact GetContactByEmail(string email, int tenantId)
        {
            return _contactRepository.Table
                .FirstOrDefault(x => x.Email == email && x.TenantId == tenantId);
        }

        public Contact GetContactById(int contactId, int tenantId)
        {
            return _contactRepository.GetById(contactId);
        }

        public Contact GetContactByMobile(string mobileNumber, int tenantId)
        {
            return _contactRepository.Table
                .FirstOrDefault(x => x.Mobile == mobileNumber && x.TenantId == tenantId);
        }

        public IList<Contact> GetContacts(int tenantId)
        {
            return _contactRepository.Table.Where(x=>x.TenantId ==tenantId).ToList();
        }

        public void UpdateContact(Contact contact)
        {
            _contactRepository.Update(contact);
        }

        public Task UpdateContactAsync(Contact contact)
        {
            throw new NotImplementedException();
        }

        void IContactService.AddContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
