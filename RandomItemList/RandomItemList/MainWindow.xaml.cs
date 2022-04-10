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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RandomItemList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const char SPLITCHAR = ';';
       
        public MainWindow()
        {
            InitializeComponent();
            txtItems.Text = Properties.Settings.Default.strList;
            Random = new Random();
            tbUsoLista.Text = tbUsoLista.Text.Replace('#', SPLITCHAR);
        }
        public Random Random { get; set; }


        private void btnRandom_Click(object sender, RoutedEventArgs e)
        {
            string[] items;
            if (!string.IsNullOrEmpty(txtItems.Text))
            {
                if (txtItems.Text.Contains(SPLITCHAR))
                {
                    items = txtItems.Text.Split(SPLITCHAR);
                    tbRandomItem.Text = items[Random.Next(items.Length)];
                }
                else tbRandomItem.Text = txtItems.Text;
            }
            else tbRandomItem.Text = string.Empty;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Properties.Settings.Default.strList = txtItems.Text;
            Properties.Settings.Default.Save();
        }
    }
}
