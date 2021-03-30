using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts
{
    public class MobilePhone : IPhone
    {
        public string NumOfTele { get; set; }

        public string GetTypeName()
        {
            return "Мобильный";
        }
    }
}
