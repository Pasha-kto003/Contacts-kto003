using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts
{
    public class Phones
    {
        public List<IPhone> ListPhones { get; set; }
        public IPhone DefaultPhone { get; set; }

        public void ChangePhoneType(IPhone phone)
        {
            int index = ListPhones.IndexOf(phone);
            if (index == -1)
                return;
            IPhone newPhone = null;
            if (phone is MobilePhone)
            {
                newPhone = new TownPhone();
                newPhone.NumOfTele = phone.NumOfTele;
            }
            if (phone is TownPhone)
            {
                newPhone = new MobilePhone();
                newPhone.NumOfTele = phone.NumOfTele;
            }
            if (phone.Equals(DefaultPhone))
            {
                DefaultPhone = newPhone;
            }
            ListPhones.Remove(phone);
            ListPhones.Insert(index, newPhone);
        }
    }
}
