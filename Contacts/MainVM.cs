using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Controls;
using Mvvm1125;
using static System.Net.Mime.MediaTypeNames;

namespace Contacts
{
    public class MainVM : MvvmNotify
    {
        public ObservableCollection<Contact> Contacts { get; set; }
        public MvvmCommand GetContact { get; set; }
        public MvvmCommand EditSelectedContact { get; set; }
        public MvvmCommand RemoveContact { get; set; }
        public MvvmCommand Search { get; set; }
        public MvvmCommand ClearSearch { get; set; }

        public string SearchText { get; set; }
        public SearchTypes SearchTypes { get; set; }
        private Contact contact;
        public Contact Contact { get => contact; set { contact = value; NotifyPropertyChanged(); } }
        public ComboBoxItem SelectedSearchType { get; set; }
        Model model;

        public MainVM()
        {
            this.model = Model.GetInstance();
            model.Load();
            Contacts = model.GetContacts();
            model.ContactChanged += Model_ContactChenged;
            GetContact = new MvvmCommand(() => { model.CreateContact(); new GetContact(model).Show(); }, () => true);
            EditSelectedContact = new MvvmCommand(() => { model.SetEditStudent(Contact); new GetContact(model).Show(); }, ()=> Contact != null);
            RemoveContact = new MvvmCommand(() => { model.RemoveContact(Contact); }, () => true);
            Search = new MvvmCommand(() => UpdateContacts(), () => true);
            ClearSearch = new MvvmCommand(() => { SearchText = ""; NotifyPropertyChanged("SearchText"); UpdateContacts(); }, () => true);
        }

        public void UpdateContacts()
        {
            //Contacts = new ObservableCollection<Contact>(model.GetContacts());
            SearchTypes id = (SearchTypes)int.Parse((string)SelectedSearchType.Tag);

            var contacts = model.SearchContacts(id, SearchText);
            Contacts = new ObservableCollection<Contact>(contacts);
            NotifyPropertyChanged("Contacts");
        }

        private void Model_ContactChenged(object sender, EventArgs e)
        {
            Contacts = model.GetContacts();
            NotifyPropertyChanged("Contacts");
        }
    }
}
