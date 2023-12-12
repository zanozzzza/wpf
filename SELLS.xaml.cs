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
    /// Логика взаимодействия для SELLS.xaml
    /// </summary>
    public partial class SELLS : Window
    {
        XDocument doc;
        public SELLS()
        {
            InitializeComponent();
            doc = XDocument.Load("C:\\Users\\Admin\\Source\\Repos\\WpfApp1\\sells.xml");
            var SELLS = (from x in doc.Element("Sells").Elements("Sell")
                         orderby x.Element("KodI").Value
                         select new
                         {
                             Код = x.Element("KodI").Value,
                             Дата = x.Element("Date").Value,
                             Фамилия = x.Element("FamilC").Value,
                             Имя = x.Element("NameC").Value,
                             Отчество = x.Element("OtchC").Value

                         }).ToList();

            dg.ItemsSource = SELLS;
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
