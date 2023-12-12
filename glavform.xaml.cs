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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для glavform.xaml
    /// </summary>
    /// 

    public partial class glavform : Window
    {
        XDocument doc1;
        XDocument doc2;
        XDocument doc3;
        XDocument doc0;

        private int counter = 0;
        private bool yesno = false;
        public glavform()
        {
            InitializeComponent();

            doc0 = XDocument.Load("C:\\Users\\Admin\\Desktop\\WpfApp1\\sells.xml");
            var SELLS = (from x in doc0.Element("Sells").Elements("Sell")
                         orderby x.Element("KodI").Value
                         select new
                         {
                             Код = x.Element("KodI").Value,
                             Дата = x.Element("Date").Value,
                             Фамилия = x.Element("FamilC").Value,
                             Имя = x.Element("NameC").Value,
                             Отчество = x.Element("OtchC").Value,
                             Изделие = x.Element("Izdelie").Value

                         }).ToList();

            dg.ItemsSource = SELLS;

        }
        
        private void ITEMS()
        {
            doc1 = XDocument.Load("C:\\Users\\Admin\\Desktop\\WpfApp1\\Items.xml");
            var ITEMS = (from x in doc1.Element("Items").Elements("Item")
                         orderby x.Attribute("KodI").Value
                         select new
                         {
                             Код = x.Attribute("KodI").Value,
                             Название = x.Element("NameI").Value,
                             Тип = x.Element("TypeI").Value,
                             Материал = x.Element("KodM").Value,
                             Вес = x.Element("Weight").Value,
                             Цена = x.Element("Price").Value

                         }).ToList();

            dg.ItemsSource = ITEMS;

            dobavlenie1.Clear();
            dobavlenie2.Clear();
            dobavlenie3.Clear();
            dobavlenie4.Clear();
            dobavlenie5.Clear();
            dobavlenie6.Clear();
        }
        private void MATERIALS()
        {
            doc2 = XDocument.Load("C:\\Users\\Admin\\Desktop\\WpfApp1\\materials.xml");
            var MATERIALS = (from x in doc2.Element("Materials").Elements("Material")
                             orderby x.Attribute("KodM").Value
                             select new
                             {
                                 Код = x.Attribute("KodM").Value,
                                 Название = x.Element("NameM").Value,
                                 Цена = x.Element("PriceG").Value

                             }).ToList();
                       
            dg.ItemsSource = MATERIALS;

            dobavlenie1.Clear();
            dobavlenie2.Clear();
            dobavlenie3.Clear();
            dobavlenie4.Clear();
            dobavlenie5.Clear();
            dobavlenie6.Clear();
        }
        private void CUST()
        {
            doc3 = XDocument.Load("C:\\Users\\Admin\\Desktop\\WpfApp1\\cust.xml");
            var CUSTS = (from x in doc3.Element("Custs").Elements("Cust")
                         orderby x.Attribute("Kod").Value
                         select new
                         {
                             Код = x.Attribute("Kod").Value,
                             Дата = x.Element("Date").Value,
                             Фамилия = x.Element("FamilC").Value,
                             Имя = x.Element("NameC").Value,
                             Отчество = x.Element("OtchC").Value

                         }).ToList();
                        
            dg.ItemsSource = CUSTS;

            dobavlenie1.Clear();
            dobavlenie2.Clear();
            dobavlenie3.Clear();
            dobavlenie4.Clear();
            dobavlenie5.Clear();
            dobavlenie6.Clear();
        }

        private void MenuItem1_Click(object sender, RoutedEventArgs e)
        {
            counter = 1;
            dobavlenie4.Visibility = Visibility.Visible;
            dobavlenie5.Visibility = Visibility.Visible;
            dobavlenie6.Visibility = Visibility.Visible;
            Items.Visibility = Visibility.Visible;
            Materials.Visibility = Visibility.Hidden;
            Sells.Visibility = Visibility.Hidden;
            Pokupki.Visibility = Visibility.Hidden;

            ITEMS();
        }

        private void MenuItem2_Click(object sender, RoutedEventArgs e)
        {
            counter = 2;
            dobavlenie4.Visibility = Visibility.Hidden;
            dobavlenie5.Visibility = Visibility.Hidden;
            dobavlenie6.Visibility = Visibility.Hidden;
            Items.Visibility = Visibility.Hidden;
            Materials.Visibility = Visibility.Visible;
            Sells.Visibility = Visibility.Hidden;
            Pokupki.Visibility = Visibility.Hidden;

            MATERIALS();
        }

        private void MenuItem3_Click(object sender, RoutedEventArgs e)
        {
            counter = 3;
            dobavlenie4.Visibility = Visibility.Visible;
            dobavlenie5.Visibility = Visibility.Visible;
            dobavlenie6.Visibility = Visibility.Hidden;
            Items.Visibility = Visibility.Hidden;
            Materials.Visibility = Visibility.Hidden;
            Sells.Visibility = Visibility.Visible;
            Pokupki.Visibility = Visibility.Hidden;

            CUST();
        }
        private void MenuItemDobav_Click(object sender, RoutedEventArgs e)
        {
            dobav.Visibility = Visibility.Visible;
            red.Visibility = Visibility.Hidden;
            del.Visibility = Visibility.Hidden;
            poisk.Visibility = Visibility.Hidden;
            Pokupka.Visibility = Visibility.Hidden;
            
        }
        private void MenuItemRed_Click(object sender, RoutedEventArgs e)
        {
            dobav.Visibility = Visibility.Hidden;
            red.Visibility = Visibility.Visible;
            del.Visibility = Visibility.Hidden;
            poisk.Visibility = Visibility.Hidden;
            Pokupka.Visibility = Visibility.Hidden;
        }

        private void MenuItemDel_Click(object sender, RoutedEventArgs e)
        {
            dobav.Visibility = Visibility.Hidden;
            red.Visibility = Visibility.Hidden;
            del.Visibility = Visibility.Visible;
            poisk.Visibility = Visibility.Hidden;
            Pokupka.Visibility = Visibility.Hidden;
        }
        private void MenuItemPoisk_Click(object sender, RoutedEventArgs e)
        {
            dobav.Visibility = Visibility.Hidden;
            red.Visibility = Visibility.Hidden;
            del.Visibility = Visibility.Hidden;
            poisk.Visibility = Visibility.Visible;
            Pokupka.Visibility = Visibility.Hidden;
        }

        private void MenuItem4_Click(object sender, RoutedEventArgs e)
        {
            counter = 0;

            dobavlenie4.Visibility = Visibility.Visible;
            dobavlenie5.Visibility = Visibility.Visible;
            dobavlenie6.Visibility = Visibility.Visible;
            Items.Visibility = Visibility.Hidden;
            Materials.Visibility = Visibility.Hidden;
            Sells.Visibility = Visibility.Hidden;
            dobav.Visibility = Visibility.Hidden;
            red.Visibility = Visibility.Hidden;
            del.Visibility = Visibility.Hidden;
            poisk.Visibility = Visibility.Hidden;
            Pokupka.Visibility = Visibility.Visible;
            Pokupki.Visibility = Visibility.Visible;

            doc0 = XDocument.Load("C:\\Users\\Admin\\Desktop\\WpfApp1\\sells.xml");
            var SELLS = (from x in doc0.Element("Sells").Elements("Sell")
                         orderby x.Element("KodI").Value
                         select new
                         {
                             Код = x.Element("KodI").Value,
                             Дата = x.Element("Date").Value,
                             Фамилия = x.Element("FamilC").Value,
                             Имя = x.Element("NameC").Value,
                             Отчество = x.Element("OtchC").Value,
                             Изделие = x.Element("Izdelie").Value

                         }).ToList();
                        
            dg.ItemsSource = SELLS;


        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void buttondobav_Click(object sender, RoutedEventArgs e)
        {
            if (counter == 1)
            {
                doc1.Element("Items").Add(new XElement("Item",
                new XAttribute("KodI", dobavlenie1.Text),
                new XElement("NameI", dobavlenie2.Text),
                new XElement("TypeI", dobavlenie3.Text),
                new XElement("KodM", dobavlenie4.Text),
                new XElement("Weight", dobavlenie5.Text),
                new XElement("Price", dobavlenie6.Text)));

                doc1.Save("C:\\Users\\Admin\\Desktop\\WpfApp1\\Items.xml");

                MessageBox.Show("Новые данные добавлены!");

                ITEMS();

                dobavlenie1.Clear();
                dobavlenie2.Clear();
                dobavlenie3.Clear();
                dobavlenie4.Clear();
                dobavlenie5.Clear();
                dobavlenie6.Clear();
            }


            if (counter == 2)
            {

               doc2.Element("Materials").Add(new XElement("Material",
               new XAttribute("KodM", dobavlenie1.Text),
               new XElement("NameM", dobavlenie2.Text),
               new XElement("PriceG", dobavlenie3.Text)));

                doc2.Save("C:\\Users\\Admin\\Desktop\\WpfApp1\\materials.xml");

                MessageBox.Show("Новые данные добавлены!");

                MATERIALS();

                dobavlenie1.Clear();
                dobavlenie2.Clear();
                dobavlenie3.Clear();
                dobavlenie4.Clear();
                dobavlenie5.Clear();
                dobavlenie6.Clear();
            }
            if (counter == 3)
            {
               doc3.Element("Custs").Add(new XElement("Cust",
               new XAttribute("Kod", dobavlenie1.Text),
               new XElement("Date", dobavlenie2.Text),
               new XElement("FamilC", dobavlenie3.Text),
               new XElement("NameC", dobavlenie4.Text),
               new XElement("OtchC", dobavlenie5.Text)));

                doc3.Save("C:\\Users\\Admin\\Desktop\\WpfApp1\\cust.xml");

                MessageBox.Show("Новые данные добавлены!");

                CUST();

                dobavlenie1.Clear();
                dobavlenie2.Clear();
                dobavlenie3.Clear();
                dobavlenie4.Clear();
                dobavlenie5.Clear();
                dobavlenie6.Clear();
            }
        }

        private void buttonred_Click(object sender, RoutedEventArgs e)
        {
            if (counter == 1)
            {
                IEnumerable<XElement> tests =
                from el in doc1.Elements("Items").Elements("Item")
                where (string)el.Attribute("KodI") == dobavlenie1.Text
                select el;
                foreach (XElement el in tests)
                    yesno = true;
                if (yesno == true)
                {
                    doc1.Elements("Items").Elements("Item").First(b => ((string)b.Attribute("KodI")) == dobavlenie1.Text).SetElementValue("NameI", dobavlenie2.Text);
                    doc1.Elements("Items").Elements("Item").First(b => ((string)b.Attribute("KodI")) == dobavlenie1.Text).SetElementValue("TypeI", dobavlenie3.Text);
                    doc1.Elements("Items").Elements("Item").First(b => ((string)b.Attribute("KodI")) == dobavlenie1.Text).SetElementValue("KodM", dobavlenie4.Text);
                    doc1.Elements("Items").Elements("Item").First(b => ((string)b.Attribute("KodI")) == dobavlenie1.Text).SetElementValue("Weight", dobavlenie5.Text);
                    doc1.Elements("Items").Elements("Item").First(b => ((string)b.Attribute("KodI")) == dobavlenie1.Text).SetElementValue("Price", dobavlenie6.Text);

                    doc1.Save("C:\\Users\\Admin\\Desktop\\WpfApp1\\Items.xml");

                    ITEMS();

                    MessageBox.Show("Данные отредактированы");
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
                dobavlenie1.Clear();
                dobavlenie2.Clear();
                dobavlenie3.Clear();
                dobavlenie4.Clear();
                dobavlenie5.Clear();
                dobavlenie6.Clear();
            }
            if (counter == 2)
            {
                IEnumerable<XElement> tests =
                from el in doc2.Elements("Materials").Elements("Material")
                where (string)el.Attribute("KodM") == dobavlenie1.Text
                select el;
                foreach (XElement el in tests)
                    yesno = true;
                if (yesno == true)
                {
                    doc2.Elements("Materials").Elements("Material").First(b => ((string)b.Attribute("KodM")) == dobavlenie1.Text).SetElementValue("NameM", dobavlenie2.Text);
                    doc2.Elements("Materials").Elements("Material").First(b => ((string)b.Attribute("KodM")) == dobavlenie1.Text).SetElementValue("PriceG", dobavlenie3.Text);

                    doc2.Save("C:\\Users\\Admin\\Desktop\\WpfApp1\\materials.xml");

                    MATERIALS();

                    MessageBox.Show("Данные отредактированы");
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
                dobavlenie1.Clear();
                dobavlenie2.Clear();
                dobavlenie3.Clear();
                dobavlenie4.Clear();
                dobavlenie5.Clear();
                dobavlenie6.Clear();
            }
            if (counter == 3)
            {
                IEnumerable<XElement> tests =
                from el in doc3.Elements("Custs").Elements("Cust")
                where (string)el.Attribute("Kod") == dobavlenie1.Text
                select el;
                foreach (XElement el in tests)
                    yesno = true;
                if (yesno == true)
                {
                    doc2.Elements("Custs").Elements("Cust").First(b => ((string)b.Attribute("Kod")) == dobavlenie1.Text).SetElementValue("Date", dobavlenie2.Text);
                    doc2.Elements("Custs").Elements("Cust").First(b => ((string)b.Attribute("Kod")) == dobavlenie1.Text).SetElementValue("FamilC", dobavlenie3.Text);
                    doc2.Elements("Custs").Elements("Cust").First(b => ((string)b.Attribute("Kod")) == dobavlenie1.Text).SetElementValue("NameC", dobavlenie4.Text);
                    doc2.Elements("Custs").Elements("Cust").First(b => ((string)b.Attribute("Kod")) == dobavlenie1.Text).SetElementValue("OtchC", dobavlenie5.Text);

                    doc3.Save("C:\\Users\\Admin\\Desktop\\WpfApp1\\cust.xml");

                    CUST();

                    MessageBox.Show("Данные отредактированы");
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
                dobavlenie1.Clear();
                dobavlenie2.Clear();
                dobavlenie3.Clear();
                dobavlenie4.Clear();
                dobavlenie5.Clear();
                dobavlenie6.Clear();
            }

        }

        private void buttondel_Click(object sender, RoutedEventArgs e)
        {
            if (counter == 1)
            {

                IEnumerable<XElement> tests =
                from el in doc1.Elements("Items").Elements("Item")
                where (string)el.Element("KodI") == dobavlenie1.Text
                select el;
                foreach (XElement el in tests)
                    yesno = true;
                if (yesno == true)
                {
                    doc1.Elements("Items").Elements("Item").First(b => ((string)b.Attribute("KodI")) == dobavlenie1.Text).Remove();

                    doc1.Save("C:\\Users\\Admin\\Desktop\\WpfApp1\\Items.xml");

                    ITEMS();

                    MessageBox.Show("Данные удалены");
                    yesno = false;

                }
                else
                {
                    MessageBox.Show("Ошибка");
                }

                    dobavlenie1.Clear();
                    dobavlenie2.Clear();
                    dobavlenie3.Clear();
                    dobavlenie4.Clear();
                    dobavlenie5.Clear();
                    dobavlenie6.Clear();
               
            }
            if (counter == 2)
            {
                IEnumerable<XElement> tests =
                from el in doc2.Elements("Materials").Elements("Material")
                where (string)el.Attribute("KodM") == dobavlenie1.Text
                select el;
                foreach (XElement el in tests)
                    yesno = true;
                if (yesno == true)
                {
                    doc2.Elements("Materials").Elements("Material").First(b => ((string)b.Attribute("KodM")) == dobavlenie1.Text).Remove();

                    doc2.Save("C:\\Users\\Admin\\Desktop\\WpfApp1\\materials.xml");

                    MATERIALS();

                    MessageBox.Show("Данные удалены");
                    yesno = false;
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
                dobavlenie1.Clear();
                dobavlenie2.Clear();
                dobavlenie3.Clear();
                dobavlenie4.Clear();
                dobavlenie5.Clear();
                dobavlenie6.Clear();
            }
            if (counter == 3)
            {
                IEnumerable<XElement> tests =
                from el in doc3.Elements("Custs").Elements("Cust")
                where (string)el.Attribute("Kod") == dobavlenie1.Text
                select el;
                foreach (XElement el in tests)
                    yesno = true;
                if (yesno == true)
                {
                    doc3.Elements("Custs").Elements("Cust").First(b => ((string)b.Attribute("Kod")) == dobavlenie1.Text).Remove();

                    doc3.Save("C:\\Users\\Admin\\Desktop\\WpfApp1\\cust.xml");

                    CUST();

                    MessageBox.Show("Данные удалены");
                    yesno = false;
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
                dobavlenie1.Clear();
                dobavlenie2.Clear();
                dobavlenie3.Clear();
                dobavlenie4.Clear();
                dobavlenie5.Clear();
                dobavlenie6.Clear();
            }
        }

        private void buttonpoisk_Click(object sender, RoutedEventArgs e)
        {
            if (counter == 1)
            {
                if (dobavlenie1.Text == "всё")
                {
                    doc1 = XDocument.Load("C:\\Users\\Admin\\Desktop\\WpfApp1\\Items.xml");
                    var ITEMS = (from x in doc1.Element("Items").Elements("Item")
                                 orderby x.Attribute("KodI").Value
                                 select new
                                 {
                                     Код = x.Attribute("KodI").Value,
                                     Название = x.Element("NameI").Value,
                                     Тип = x.Element("TypeI").Value,
                                     Материал = x.Element("KodM").Value,
                                     Вес = x.Element("Weight").Value,
                                     Цена = x.Element("Price").Value

                                 }).ToList();

                    dg.ItemsSource = ITEMS;
                }

                if (dobavlenie1 != null && dobavlenie1.Text != "всё" && dobavlenie3.Text == "")
                {
                    var kod = (from x in doc1.Element("Items").Elements("Item")
                               where (string)x.Attribute("KodI") == dobavlenie1.Text
                               select new
                               {
                                   Код = x.Attribute("KodI").Value,
                                   Название = x.Element("NameI").Value,
                                   Тип = x.Element("TypeI").Value,
                                   Материал = x.Element("KodM").Value,
                                   Вес = x.Element("Weight").Value,
                                   Цена = x.Element("Price").Value
                               }).ToList();

                    dg.ItemsSource = kod;
                }
                if (dobavlenie1.Text == "" && dobavlenie1.Text != "всё" && dobavlenie3 != null && dobavlenie3.Text != "группировать")
                {
                    var type = (from x in doc1.Element("Items").Elements("Item")
                                where (string)x.Element("TypeI") == dobavlenie3.Text
                                group x by x.Element("TypeI").Value into g
                                select new
                                {
                                    Тип = g.Key,
                                    Количество = g.Count()
                                    
                                }).ToList();

                    dg.ItemsSource = type;
                }
                if (dobavlenie1.Text == "" &&  dobavlenie1.Text != "всё" && dobavlenie3.Text == "группировать")
                {
                    var type = (from x in doc1.Element("Items").Elements("Item")
                                group x by x.Element("TypeI").Value into g
                                select new
                                {
                                    группа = g.Key
                                }).ToList();

                    dg.ItemsSource = type;
                }


                dobavlenie1.Clear();
                dobavlenie2.Clear();
                dobavlenie3.Clear();
                dobavlenie4.Clear();
                dobavlenie5.Clear();
                dobavlenie6.Clear();
            }
            if (counter == 2)
            {
                if (dobavlenie1.Text == "всё")
                {
                    MATERIALS();
                }
                if (dobavlenie1.Text != "всё")
                {
                    var kodm = (from x in doc2.Element("Materials").Elements("Material")
                                where (string)x.Attribute("KodM") == dobavlenie1.Text && (string)x.Element("PriceG") == dobavlenie3.Text
                                select new
                                {
                                    Код = x.Attribute("KodM").Value,
                                    Название = x.Element("NameM").Value,
                                    Цена = x.Element("PriceG").Value
                                }).ToList();

                    dg.ItemsSource = kodm;

                }

                dobavlenie1.Clear();
                dobavlenie2.Clear();
                dobavlenie3.Clear();
                dobavlenie4.Clear();
                dobavlenie5.Clear();
                dobavlenie6.Clear();
            }

            if (counter == 3)
            {
                if (dobavlenie1.Text == "всё")
                {
                    CUST();
                }
                if (dobavlenie1.Text != "всё")
                {
                    var sell = (from x in doc3.Element("Custs").Elements("Cust")
                                where (string)x.Attribute("Kod") == dobavlenie1.Text || (string)x.Element("NameC") == dobavlenie4.Text
                                select new
                                {
                                    Код = x.Attribute("Kod").Value,
                                    Дата = x.Element("Date").Value,
                                    Фамилия = x.Element("FamilC").Value,
                                    Имя = x.Element("NameC").Value,
                                    Отчество = x.Element("OtchC").Value
                                }).ToList();

                    dg.ItemsSource = sell;
                }


                dobavlenie1.Clear();
                dobavlenie2.Clear();
                dobavlenie3.Clear();
                dobavlenie4.Clear();
                dobavlenie5.Clear();
                dobavlenie6.Clear();
            }


        }


        private void oform_Click(object sender, RoutedEventArgs e)
        {
            doc0.Element("Sells").Add(new XElement("Sell",
                new XElement("KodI", dobavlenie1.Text),
                new XElement("Date", dobavlenie2.Text),
                new XElement("FamilC", dobavlenie3.Text),
                new XElement("NameC", dobavlenie4.Text),
                new XElement("OtchC", dobavlenie5.Text),
                new XElement("Izdelie", dobavlenie6.Text)));

            doc0.Save("C:\\Users\\Admin\\Desktop\\WpfApp1\\sells.xml");

            MessageBox.Show("Новые данные добавлены!");

            var SELLS = (from x in doc0.Element("Sells").Elements("Sell")
                         orderby x.Element("KodI").Value
                         select new
                         {
                             Код = x.Element("KodI").Value,
                             Дата = x.Element("Date").Value,
                             Фамилия = x.Element("FamilC").Value,
                             Имя = x.Element("NameC").Value,
                             Отчество = x.Element("OtchC").Value,
                             Изделие = x.Element("Izdelie").Value

                         }).ToList();
            dg.ItemsSource = SELLS;
        }

    }

}
