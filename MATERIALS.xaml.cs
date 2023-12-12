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
    /// Логика взаимодействия для MATERIALS.xaml
    /// </summary>
    public partial class MATERIALS : Window
    {
        XDocument doc;
        public MATERIALS()
        {
            InitializeComponent();
            doc = XDocument.Load("C:\\Users\\Admin\\Source\\Repos\\WpfApp1\\materials.xml");
            var MATERIALS = (from x in doc.Element("Materials").Elements("Material")
                         orderby x.Element("KodM").Value
                         select new
                         {
                             Код = x.Element("KodM").Value,
                             Название = x.Element("NameM").Value,
                             Цена = x.Element("PriceG").Value,
                             Материал = x.Element("KodM").Value

                         }).ToList();

            dg.ItemsSource = MATERIALS;
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
