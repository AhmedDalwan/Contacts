
namespace Contacts.Maui.Models
{
    public static class ContactRepository
    {
        public static List<Contact> _contacts = new List<Contact>
        {
            new Contact
            {
                Id = 1, Name ="Ahmed", Email="ahmed@gmail.com"
            },
            new Contact
            {
                Id = 2, Name ="Omar", Email="omar@gmail.com"
            },
            new Contact
            {
                Id = 3, Name ="Mhmd", Email="mhmd@gmail.com"
            },
            new Contact
            {
                Id = 4, Name ="Ali", Email="ali@gmail.com"
            }
        };

        public static List<Contact> GetContacts() => _contacts;

        public static Contact? GetContactById(int id)
        {
            var contact = _contacts.FirstOrDefault(x => x.Id == id);
            if (contact is null)
            {
                return null;
            }
            return new Contact
            {
                Id = id,
                Name = contact.Name,
                Email = contact.Email,
                Phone = contact.Phone,
                Address = contact.Address,
            };
        }

        public static void UpdateContact(int contactId, Contact contact)
        {
            if (contactId != contact.Id)
            {
                return;
            }
            var contactToUpdate = _contacts.FirstOrDefault(f => f.Id == contactId);
            if (contactToUpdate != null)
            {
                // AutoMapper
                contactToUpdate.Name = contact.Name;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Phone = contact.Phone;
                contactToUpdate.Address = contact.Address;
            }
        }

        public static void AddContact(Contact contact)
        {
            var maxId = _contacts.Max(x => x.Id);
            contact.Id = maxId + 1;
            _contacts.Add(contact);
        }

        public static void DeleteContact(int contactId)
        {
            var contact = _contacts.FirstOrDefault(f => f.Id == contactId);
            if (contact != null)
            {
                _contacts.Remove(contact);
            }
        }

        public static List<Contact> SearchContacts(string filterText)
        {
            var contacts = _contacts.Where(w => !string.IsNullOrEmpty(w.Name) && w.Name.StartsWith(filterText, StringComparison.OrdinalIgnoreCase)).ToList();
            if (contacts.Count <= 0)
            {
                contacts = _contacts.Where(w => !string.IsNullOrEmpty(w.Email) && w.Email.StartsWith(filterText, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                return contacts;
            }
            if (contacts.Count <= 0)
            {
                contacts = _contacts.Where(w => !string.IsNullOrEmpty(w.Phone) && w.Phone.StartsWith(filterText, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                return contacts;
            }
            if (contacts.Count <= 0)
            {
                contacts = _contacts.Where(w => !string.IsNullOrEmpty(w.Address) && w.Address.StartsWith(filterText, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                return contacts;
            }
            return contacts;
        }
    }
}
