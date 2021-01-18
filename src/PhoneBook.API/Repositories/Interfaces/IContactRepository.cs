using PhoneBook.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API.Repositories.Interfaces
{
    public interface IContactRepository
    {
        //Rehberde kişi oluşturma
        Task Create(Contact contact);
        
        //Rehberde kişi kaldırma
        Task<bool> Delete(string id);

        //Rehberdeki kişiye iletişim bilgisi ekleme
        Task AddContactInfo(string id, ContactInfo contactInfo);

        //Rehberdeki kişiden iletişim bilgisi kaldırma
        Task DeleteContactInfo(string id, long PhoneNumber);

        //Rehberdeki kişilerin listelenmesi
        Task<IEnumerable<Contact>> GetContacts();

        //Rehberdeki bir kişiyle ilgili iletişim bilgilerinin de yer aldığı detay bilgilerin getirilmesi
        Task<Contact> GetContactById(string id);



    }
}
