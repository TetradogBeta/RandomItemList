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
        const string VERSION = "2.0";
        public MainWindow()
        {
            InitializeComponent();
            txtItems.Text = Properties.Settings.Default.strList;
            Random = new Random();
            tbUsoLista.Text = tbUsoLista.Text.Replace('#', SPLITCHAR);
            LastIndex = -1;
            LastColorIndex = 0;
            Title = Title + VERSION;
        }
        public Random Random { get; set; }
        public int LastIndex { get; set; }

        public int LastColorIndex { get; set; }
        public SolidColorBrush[] Colores => new SolidColorBrush[] { Brushes.Blue,Brushes.Salmon,Brushes.Violet,Brushes.Tomato,Brushes.Green };

        private void btnRandom_Click(object sender, RoutedEventArgs e)
        {
            string[] items;
            int index;
            if (!string.IsNullOrEmpty(txtItems.Text))
            {
                if (txtItems.Text.Contains(SPLITCHAR))
                {
                    items = txtItems.Text.Split(SPLITCHAR);
                    index = Random.Next(items.Length);
                    tbRandomItem.Text = items[index];
                    if (index == LastIndex)
                    {
                        //cambio color letra
                        tbRandomItem.Foreground = Colores[LastColorIndex];

                        LastColorIndex = (LastColorIndex + 1) % Colores.Length;
                    }
                    else
                    {
                        //pongo colo negro
                        tbRandomItem.Foreground = Brushes.Black;
                    }
                    LastIndex = index;
                }
                else { 
                    tbRandomItem.Text = txtItems.Text;
                    tbRandomItem.Foreground = Brushes.Black;
                }
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
