﻿using System;
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

            DataContext = new ViewModel();

            UIManager.CreateMatrix<Button,EmptyField>(25, 25, ParrentGrid,(control)=> 
            {
               // control.IsEnabled = false;
                control.MouseLeave += (o,s)=> control.Background = new SolidColorBrush(Colors.Blue);
            });
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
           // TankField emptyPoint = new TankField((Button)sender);
        }
    }
}
