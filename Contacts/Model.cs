using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Contacts
{
   public class Model
    {
        ContactsDB contactsDB = new ContactsDB();

        public event EventHandler EditContactChanged;
        public event EventHandler ContactChanged;

        static Model instance;
        public static Model GetInstance()
        {
            if (instance == null)
                instance = new Model();
            return instance;
        }

        public Contact editContact;

        public Contact EditContact
        {
            get => editContact; 
            set
            {
                editContact = value;
                EditContactChanged?.Invoke(this, null);
            }
        }

        internal ObservableCollection<Contact> GetContacts()
        {
            return contactsDB.GetContacts();
        }


        internal void Load()
        {
            contactsDB.Load();
        }
        
        internal void Save()
        {
            contactsDB.Save();
        }

        internal void RemoveContact(Contact contact)
        {
            contactsDB.Remove(contact);
            ContactChanged?.Invoke(this, null);
            Save();
        }

        internal List<Contact> SearchContacts(SearchTypes id, string searchText)
        {
            contactsDB.SearchText = searchText;
            contactsDB.SearchType = id;
            return contactsDB.Search();
        }

        internal void SetEditStudent(Contact contact)
        {
            EditContact = contact;
        }

        internal void CreateContact()
        {
            EditContact = contactsDB.CreateContact();
            ContactChanged?.Invoke(this, null);
            Save();
        }



    }
}
