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
using Tanks.UserInterface;

namespace Tanks.View.Controls
{
    public class BattleFieldControl : Grid
    {
        public Control[,] ControlsMatrix { get; private set; }


        public static readonly DependencyProperty TestPropProperty =
      DependencyProperty.Register(nameof(TestProp), typeof(bool[,]), typeof(BattleFieldControl), new UIPropertyMetadata(null));

        public bool[,] TestProp
        {
            get { return (bool[,])GetValue(TestPropProperty); }
            set {SetValue(TestPropProperty, value);}
        }

        static BattleFieldControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BattleFieldControl), new FrameworkPropertyMetadata(typeof(BattleFieldControl)));
        }

        public BattleFieldControl()
        { 
            Loaded += BattleFieldControl_Loaded;
        }

        private void BattleFieldControl_Loaded(object sender, RoutedEventArgs e)
        {
            ControlsMatrix = UIManager.CreateMatrix<Button>(this.SizeX, this.SizeY, this);


            //MessageBox.Show(TestProp?.ToString());
        }

        public int SizeX { get; set; }

        public int SizeY { get; set; }



        private void Initialize()
        {
            for (int i = 0; i < SizeX; i++)
            {
                for (int j = 0; j < SizeY; j++)
                {
                    throw new NotImplementedException();
                   // this.TestProp[i,j]
                }
            }
        }
    }
}
