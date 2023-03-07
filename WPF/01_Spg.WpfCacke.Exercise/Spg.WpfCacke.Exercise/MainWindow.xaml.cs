using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace Spg.WpfCacke.Exercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //this.GetType().GetProperties
            //Colors
            //object
            InitializeComponent();

            Person p = new Person("Martin", "Schrutek");

            Type personType = p.GetType();

            List<PropertyInfo> props = personType.GetProperties().ToList();

        }
    }
}
