using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void TextBoxPasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        public void ButtonClickCount(object sender, RoutedEventArgs e)
        {
            InputTry(module1.Text, module2.Text, module3.Text);



        }



        public bool InputTry(string module1, string module2, string module3)
        {
            if (string.IsNullOrEmpty(module1) || string.IsNullOrEmpty(module2) || string.IsNullOrEmpty(module3))
            {
                MessageBox.Show("Одно из полей осталось незаполненным!");
                return false;
            }
            if ((Convert.ToInt32(module1) > 22) || (Convert.ToInt32(module1) < 0))
            {
                MessageBox.Show("Неккоректное кол-во баллов в модуле 1");
                return false;
            }
            if ((Convert.ToInt32(module2) > 38) || (Convert.ToInt32(module2) < 0))
            {
                MessageBox.Show("Неккоректное кол-во баллов в модуле 2");
                return false;
            }
            if ((Convert.ToInt32(module3) > 20) || (Convert.ToInt32(module3) < 0))
            {
                MessageBox.Show("Неккоректное кол-во баллов в модуле 3");
                return false;
            }

            ammount.Text = Convert.ToString(Convert.ToInt32(module1) + Convert.ToInt32(module2) + Convert.ToInt32(module3));
            if (Convert.ToInt32(ammount.Text) < 16)
            {
                garde.Text = "2";
                return true;
            }
            if (Convert.ToInt32(ammount.Text) > 15 && Convert.ToInt32(ammount.Text) < 32)
            {
                garde.Text = "3";
                return true;
            }
            if (Convert.ToInt32(ammount.Text) > 31 && Convert.ToInt32(ammount.Text) < 56)
            {
                garde.Text = "4";
                return true;
            }
            if (Convert.ToInt32(ammount.Text) > 55)
            {
                garde.Text = "5";
                return true;
            }
            else
            {
                return false;
            }
        }



        public void ButtonClear(object sender, RoutedEventArgs e)
        {
            module1.Clear();
            module2.Clear();
            module3.Clear();
            ammount.Text = "";
            garde.Text = "";
        }

        private void module1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);

        }
    }
}
