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
using Tanks.Dictionary;
using Tanks.Models;
using Tanks.View.UserInterface;
using TraversalLib;

namespace Tanks.View.Controls
{
    public class BattleFieldControl : Grid
    {
        #region Units
        public static readonly DependencyProperty SpotsMatrixProperty =
         DependencyProperty.Register(nameof(SpotsMatrix), typeof(UnitSlot[,]), typeof(BattleFieldControl), new UIPropertyMetadata(null));
        #endregion

        #region Initialization

        #region Constructor
        static BattleFieldControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BattleFieldControl), new FrameworkPropertyMetadata(typeof(BattleFieldControl)));
        }

        public BattleFieldControl()
        {
            this.Loaded += this.BattleFieldControl_Loaded;
        }
        #endregion

        private void BattleFieldControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Create control matrix
            this.ControlsMatrix = new UiManager(this.ControlSize).CreateMatrix<Label>(this.SizeX, this.SizeY, this);

            // Initialize UI & Bind 
            this.Initialize();

            // Modify controls
            UiManager.ModifyMatrix(this.ControlsMatrix, this.ControlModify);
        }

        private void Initialize()
        {
            //Initialize color
            TREXCM.RecursiveTraversal(
                (os, parms) => this.PaintControl((Control)os[1], (UnitSlot)os[0]), this.SpotsMatrix, this.ControlsMatrix
                );

            //Bind
            TREXCM.RecursiveTraversal(
                (os, parms) => this.BindAction((UnitSlot)os[0], (Control)os[1]), this.SpotsMatrix, this.ControlsMatrix
                );
        }

        private void ControlModify(Control control)
        {
            control.Margin = new Thickness(2);
        }

        private void BindAction(UnitSlot slot, Control control)
        {
            slot.StateChanged += (o, s) => this.PaintControl(control, slot);
        }

        private void PaintControl(Control control, UnitSlot slot)
        {
            var state = (slot.Unit).UnitPointState;
            if (state != null)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    control.Background =
                        new SolidColorBrush(
                            (Color) ResourcesDictionary.GetDictionaryElement(state.Value, DictionaryType.Color));

                    control.ToolTip = this.SpotsMatrix[GetColumn(control), GetRow(control)].Unit.ToString();
                });

               
                
            }
            else
            {
                throw new ArgumentNullException(nameof(state) +" must not be null in battle unit");
            }
        }
    
        #endregion

        #region Properties
        public int SizeX => this.SpotsMatrix.GetLength(0);

        public int SizeY => this.SpotsMatrix.GetLength(1);

        public int ControlSize { get; set; }

        public Control[,] ControlsMatrix { get; private set; }

        public UnitSlot[,] SpotsMatrix
        {
            get { return (UnitSlot[,]) this.GetValue(SpotsMatrixProperty); }
            set { this.SetValue(SpotsMatrixProperty, value); }
        }
        #endregion
    }
}
