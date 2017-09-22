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
        #region Fields
        public static readonly DependencyProperty SpotsMatrixProperty =
         DependencyProperty.Register(nameof(SpotsMatrix), typeof(FieldSlot[,]), typeof(BattleFieldControl), new UIPropertyMetadata(null));
        #endregion

        #region Initialization

        #region Constructor
        static BattleFieldControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BattleFieldControl), new FrameworkPropertyMetadata(typeof(BattleFieldControl)));
        }

        public BattleFieldControl()
        { 
            Loaded += BattleFieldControl_Loaded;
        }
        #endregion

        private void BattleFieldControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Create control matrix
            ControlsMatrix = new UIManager(this.ControlSize).CreateMatrix<Label>(this.SizeX, this.SizeY, this);

            // Initialize UI & Bind 
            Initialize();

            // Modify controls
            UIManager.ModifyMatrix(this.ControlsMatrix, this.ControlModify);
        }

        private void Initialize()
        {
            //Initialize color
            TREXCM.RecursiveTraversal(
                (os, parms) =>
                PaintControl((Control)os[1], (FieldSlot)os[0]),
                SpotsMatrix,
                ControlsMatrix
                );

            //Bind
            TREXCM.RecursiveTraversal(
                (os, parms) =>
                BindAction((FieldSlot)os[0], (Control)os[1]),
                SpotsMatrix,
                ControlsMatrix
                );
        }

        private void ControlModify(Control control)
        {
            control.Margin = new Thickness(2);
            control.ToolTip = SpotsMatrix[GetColumn(control), GetRow(control)].Field.ToString();
        }

        private void BindAction(FieldSlot slot, Control control)
        {
            slot.StateChanged += (o, s) => PaintControl(control, slot);
        }

        private void PaintControl(Control control, FieldSlot slot)
        {
            control.Background = new SolidColorBrush((Color)ResourcesDictionary.GetDictionaryElement((slot.Field).FieldPointState, DictionaryType.Color));
        }
    
        #endregion

        #region Properties
        public int SizeX => SpotsMatrix.GetLength(0);

        public int SizeY => SpotsMatrix.GetLength(1);

        public int ControlSize { get; set; }

        public Control[,] ControlsMatrix { get; private set; }

        public FieldSlot[,] SpotsMatrix
        {
            get { return (FieldSlot[,])GetValue(SpotsMatrixProperty); }
            set { SetValue(SpotsMatrixProperty, value); }
        }
        #endregion
    }
}
