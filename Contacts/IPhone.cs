using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts
{
   public interface IPhone
    {
        public string NumOfTele { get; set; }

        public string GetTypeName();
    }
}
