using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Contacts
{
    public class Contact : INotifyPropertyChanged
    {
        private string name;
        private string adress;
        private DateTime dateOfBirth;
        private string numoftele;
        private string nickname;
        public NickNames Nicknames { get; set; }
        public Phones Phones { get; set; }

        public string Name { get => name; set { name = value; Signal("Name"); } }
        public string Adress { get => adress; set { adress = value; Signal("Adress"); } }
        public DateTime DateOfBirth { get => dateOfBirth; set { dateOfBirth = value; Signal("DateOfBirth"); } }
        public string NumOfTele { get => numoftele; set { numoftele = value; Signal("NumOfTele"); } }
        public string NickName { get => nickname; set { nickname = value; Signal("NickName"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Signal(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
