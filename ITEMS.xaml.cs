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
    /// Логика взаимодействия для ITEMS.xaml
    /// </summary>
    public partial class ITEMS : Window
    {
        XDocument doc;
        public ITEMS()
        {
            InitializeComponent();
            doc = XDocument.Load("C:\\Users\\Admin\\Source\\Repos\\WpfApp1\\Items.xml");
            var ITEMS = (from x in doc.Element("Items").Elements("Item")
                orderby x.Element("KodI").Value
                select new
                {
                    Код = x.Element("KodI").Value,
                    Название = x.Element("NameI").Value,
                    Тип = x.Element("TypeI").Value,
                    Материал = x.Element("KodM").Value,
                    Вес = x.Element("Weight").Value,
                    Цена = x.Element("Price").Value

                }).ToList();

            dg.ItemsSource = ITEMS;
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
