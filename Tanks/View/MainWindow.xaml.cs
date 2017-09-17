﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Tanks.Models;
using Tanks.Models.Dictionary;
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
        }

        private void butt_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            ((ViewModel)DataContext).BattleField.SetSlot(new TankField(r.Next(10), r.Next(10)));
        }
    }
}
