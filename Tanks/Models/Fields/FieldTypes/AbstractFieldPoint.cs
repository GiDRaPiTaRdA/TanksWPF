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
        FieldPointState fieldPointState;

        public Control UiElement { get; set; }
        public FieldPointState FieldPointState
        {
            get
            { return fieldPointState; }
            set
            {
                fieldPointState = value;
                OnFieldPointStateChanged();
            }
        }



        public AbstractField(Control uiElement,FieldPointState state)
        {
            this.UiElement = uiElement;
            this.FieldPointState = state;
        }

       
        private void OnFieldPointStateChanged()
        {
            UiElement.Background = new SolidColorBrush((Color)FieldsDictionary.GetDictionaryElement(this.FieldPointState,DictionaryType.Color));
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
