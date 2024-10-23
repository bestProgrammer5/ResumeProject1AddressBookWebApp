using BackEndApi.DataDbContext;
using BackEndApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace BackEndApi.Depot
{
    public class DepotTasks
    {
        private readonly ApplicationDbContext dbPriv;

        public DepotTasks(ApplicationDbContext appDbContext) 
        { 
            this.dbPriv = appDbContext;
        }


        public async Task<List<ContactVariables>> getAllContacts()
        {
            return await dbPriv.ContactVariables.ToListAsync();
        }


        public async Task saveContact(ContactVariables contact)
        {
            await dbPriv.ContactVariables.AddAsync(contact);
            await dbPriv.SaveChangesAsync();
        }


        public async Task updateContact(int id, ContactVariables con)
        {
            var contact = await dbPriv.ContactVariables.FindAsync(id);

            if (contact == null)
            {
                throw new Exception("Contact not Found.");
            }

            contact.lastName = con.lastName;
            contact.firstName = con.firstName;
            contact.phoneNumber = con.phoneNumber;
            contact.emailAddress = con.emailAddress;

            await dbPriv.SaveChangesAsync();
        }



        public async Task deleteContact(int id)
        {
            var contact = await dbPriv.ContactVariables.FindAsync(id);

            if(contact == null) {
                throw new Exception("Contact not Found");
            }

            dbPriv.ContactVariables.Remove(contact);
            await dbPriv.SaveChangesAsync();
        }



    }
}
