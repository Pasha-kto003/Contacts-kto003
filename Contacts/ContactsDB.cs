using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Contacts
{
    class ContactsDB
    {
        public List<Contact> Contacts { get; set; }
        public string SearchText { get; set; }
        public SearchTypes SearchType { get; set; }

        public List<Contact> Search()
        {
            List<Contact> contacts = new List<Contact>();
            if (SearchType == SearchTypes.SearchByName)
            {
                foreach (Contact c in Contacts)
                    if (c.Name.ToLower().Contains(SearchText.ToLower()))
                        contacts.Add(c);
            }
            if (SearchType == SearchTypes.SearchByPhone)
            {
                foreach (Contact c in Contacts)
                    if (c.Phones.ListPhones.Contains(c.Phones.ListPhones.FirstOrDefault(p => p.NumOfTele.ToLower().Contains(SearchText.ToLower()))))
                        contacts.Add(c);
            }
            if (SearchType == SearchTypes.SearchByNick)
            {
                foreach (Contact c in Contacts)
                    if (c.Nicknames.ListNicknames.Contains(c.Nicknames.ListNicknames.FirstOrDefault(p => p.Nick.ToLower().Contains(SearchText.ToLower()))))
                        contacts.Add(c);
            }
            return contacts;
        }

        internal void Remove(Contact contact)
        {
            Contacts.Remove(contact);
        }

        internal ObservableCollection<Contact> GetContacts()
        {
            return new ObservableCollection<Contact>(Contacts);
        }

        internal Contact CreateContact()
        {
            var EditContact = new Contact();
            Contacts.Add(EditContact);
            return EditContact;
        }

        private const string path = "сontacts.db";

        internal void Load()
        {
            string file = path;
            if (!File.Exists(file) || new FileInfo(file).Length == 0)
            {
                Contacts = new List<Contact>();
                return;
            }
            string json = File.ReadAllText(file);
            Contacts = (List<Contact>)JsonSerializer.Deserialize(json, typeof(List<Contact>));
        }

        internal void Save()
        {
            var json = JsonSerializer.Serialize(Contacts, typeof(List<Contact>));
            File.WriteAllText(path, json);
        }
    }
}
