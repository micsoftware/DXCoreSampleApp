using DXCoreSampleApp.Common.Domain;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXCoreSampleApp.Data
{
    public static class DatabaseContextExtensions
    {
        public static void EnsureSeedDataForContext(this DatabaseContext context)
        {
            if (context.Set<Contact>().Any())
            {
                return;
            }

            var contacts = new List<Contact>()
            {
                new Contact
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "John@doe.net",
                    Age = 27,
                    Mobile = "559 555 5555",
                    TenantId = 1
                },
                new Contact
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Email = "Jane@doe.net",
                    Age = 27,
                    Mobile = "559 555 5556",
                    TenantId = 2
                }
            };
            context.Set<Contact>().AddRange(contacts);
            context.SaveChanges();
        }
    }
}
