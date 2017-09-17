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
using Tanks.Models;
using Tanks.Models.Dictionary;
using Tanks.UserInterface;
using TraversalLib;

namespace Tanks.View.Controls
{
    public class BattleFieldControl : Grid
    {
        public int DefaultSize => 10;

        public Control[,] ControlsMatrix { get; private set; }

        public static readonly DependencyProperty SpotsMatrixProperty =
      DependencyProperty.Register(nameof(SpotsMatrix), typeof(FieldSlot[,]), typeof(BattleFieldControl), new UIPropertyMetadata(null));

        public FieldSlot[,] SpotsMatrix
        {
            get { return (FieldSlot[,])GetValue(SpotsMatrixProperty); }
            set { SetValue(SpotsMatrixProperty, value); }
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

            Initialize();
        }

        public int SizeX => SpotsMatrix.GetLength(0);

        public int SizeY => SpotsMatrix.GetLength(1);

        private void Initialize()
        {
            TREXCM.RecursiveTraversal(
                (os, parms) =>
                BindAction((FieldSlot)os[0],(Control)os[1]) ,
                SpotsMatrix,
                ControlsMatrix
                );
        }

        private void BindAction(FieldSlot slot, Control control)
        {
            (slot).StateChanged +=
                    (o, s) => { control.Background = new SolidColorBrush((Color)ResourcesDictionary.GetDictionaryElement((((SlotEventArgs)s).Field).FieldPointState, DictionaryType.Color)); ; };
        }
    }
}
