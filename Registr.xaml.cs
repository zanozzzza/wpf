using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {
        XDocument docreg;
        public Registr()
        {
            InitializeComponent();
        }

        private void buttonregistr_Click(object sender, RoutedEventArgs e)
        {
            docreg = XDocument.Load("C:\\Users\\Admin\\Desktop\\WpfApp1\\users.xml");
            docreg.Element("Users").Add(new XElement("User",
                new XElement("login", newloginbox.Text),
                new XElement("pass", newpasswordbox.Password)));

            docreg.Save("C:\\Users\\Admin\\Desktop\\WpfApp1\\users.xml");
            MessageBox.Show("Вы успешно зарегистрированы!");
            this.Close();
        }

        private void buttonvoiti_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
