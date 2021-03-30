using System;
using System.Collections.Generic;
using System.Text;
using Mvvm1125;

namespace Contacts
{
    public class GetContactVM : MvvmNotify
    {
        public Contact Contact { get; set; }
        public MvvmCommand SaveContact { get; set; }

        public GetContactVM(GetContact getContact)
        {
            Contact = Model.GetInstance().EditContact;
            SaveContact = new Mvvm1125.MvvmCommand(() => { getContact.Close(); Model.GetInstance().Save(); }, () => true);
        }
    }
}
