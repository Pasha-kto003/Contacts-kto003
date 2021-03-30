using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Contacts
{
    /// <summary>
    /// Логика взаимодействия для GetContact.xaml
    /// </summary>
    public partial class GetContact : Window
    {
        public GetContact(Model model)
        {
            InitializeComponent();
            DataContext = new GetContactVM(this);
        }
    }
}
