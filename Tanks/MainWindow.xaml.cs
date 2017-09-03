using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using Tanks.Models.Fields;
using Tanks.UserInterface;

namespace Tanks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var UiMatrix = UIManager.CreateMatrix<Label>(
               10,
               10,
               ParrentGrid,
               control => {
                   control.MouseEnter += (o, s) => control.Background = new SolidColorBrush(Colors.Blue);
                   control.Background = new SolidColorBrush(Colors.WhiteSmoke);
               });

            DataContext = new ViewModel(UiMatrix);

           

        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
           // TankField emptyPoint = new TankField((Button)sender);
        }
    }
}
