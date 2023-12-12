using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        XDocument docreg;
        


        private bool user = false;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            docreg = XDocument.Load("C:\\Users\\Admin\\Desktop\\WpfApp1\\users.xml");
            var USERS = (from x in docreg.Element("Users").Elements("User")
                         orderby x.Element("login").Value
                         select new
                         {
                             Логин = x.Element("login").Value,
                             Пароль = x.Element("pass").Value,

                         }).ToList();

            var USERSCollection = new ObservableCollection<object>(USERS);


            IEnumerable<XElement> tests =
                    from el in docreg.Elements("Users").Elements("User")
                    where (string)el.Element("login") == loginbox.Text && (string)el.Element("pass") == passwordbox.Password
                    select el;
                    foreach (XElement el in tests)
                        user = true;


            if (user == true)
            {
                glavform gf = new glavform();
                gf.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль!");
            }

        }

        private void buttonregistr_Click(object sender, RoutedEventArgs e)
        {
            Registr reg = new Registr();
            reg.ShowDialog();
        }
    }
}
