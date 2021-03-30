using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts
{
    class TownPhone : IPhone
    {
        public string NumOfTele { get; set; }

        public string GetTypeName()
        {
            return "Городской";
        }
    }
}
