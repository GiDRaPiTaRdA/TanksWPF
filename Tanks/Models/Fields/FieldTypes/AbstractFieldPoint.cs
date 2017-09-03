using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PropertyChanged;
using System.Windows.Controls;
using System.Windows.Media;
using Tanks.Models.Dictionary;

namespace Tanks.Models.Fields
{
   // [AddINotifyPropertyChangedInterface]
    abstract class AbstractField
    {
        public FieldPointState FieldPointState { get; set; }
        public int x, y = 0;

        public AbstractField(int x,int y,FieldPointState state)
        {
            this.x = x;
            this.y = y;
            this.FieldPointState = state;
        }

       
        //private void OnFieldPointStateChanged()
        //{
        //    UiElement.Background = new SolidColorBrush((Color)FieldsDictionary.GetDictionaryElement(this.FieldPointState,DictionaryType.Color));
        //}

        public void MoveUp()
        {

        }


        //public FieldPointState FieldPointState
        //{
        //    get
        //    {
        //        return fieldPointState;
        //    }
        //    set
        //    {
        //        fieldPointState = value;
        //        OnFieldPointStateChanged();
        //    }
        //}

    }
}
