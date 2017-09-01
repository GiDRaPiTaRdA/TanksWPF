using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Tanks.Models.Fields;

namespace Tanks.UserInterface
{
    class UIManager
    {
        public static int ControlSize => 25;

        public static AbstractField[,] CreateMatrix<T, FieldType>(int x, int y, Grid parrent, Action<Control> modify = null) where T : Control where FieldType : AbstractField
        {
            AbstractField[,] space = new AbstractField[x, y];

            // Add columns X
            for (int i = 0; i < x; i++)
            {
                ColumnDefinition columnDef = new ColumnDefinition();
                columnDef.Width = new GridLength(ControlSize);
                parrent.ColumnDefinitions.Add(columnDef);
            }

            // Add rows Y
            for (int i = 0; i < y; i++)
            {
                RowDefinition rowDef = new RowDefinition();
                rowDef.Height = new GridLength(ControlSize);
                parrent.RowDefinitions.Add(rowDef);
            }

            // Add to UI Elements to Parrent
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Control uiElement = (T)Activator.CreateInstance(typeof(T));

                    modify?.Invoke(uiElement);

                    Grid.SetColumn(uiElement, i);
                    Grid.SetRow(uiElement, j);
                    parrent.Children.Add(uiElement);

                    // Assign Field
                    space[i, j] = (FieldType)Activator.CreateInstance(typeof(FieldType), uiElement);
                }
            }

            return space;
        }

        public static AbstractField[,] CreateMatrix<T, FieldType>(AbstractField[,] space, Grid parrent, Action<Control> modify = null) where T : Control where FieldType : AbstractField
        {
            int x = space.GetLength(0);
            int y = space.GetLength(1);

            // Add columns X
            for (int i = 0; i < x; i++)
            {
                ColumnDefinition columnDef = new ColumnDefinition();
                columnDef.Width = new GridLength(ControlSize);
                parrent.ColumnDefinitions.Add(columnDef);
            }

            // Add rows Y
            for (int i = 0; i < y; i++)
            {
                RowDefinition rowDef = new RowDefinition();
                rowDef.Height = new GridLength(ControlSize);
                parrent.RowDefinitions.Add(rowDef);
            }

            // Add to UI Elements to Parrent
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Control uiElement = (T)Activator.CreateInstance(typeof(T));

                    modify(uiElement);

                    Grid.SetColumn(uiElement, i);
                    Grid.SetRow(uiElement, j);
                    parrent.Children.Add(uiElement);

                    // Assign Field
                    space[i, j] = (FieldType)Activator.CreateInstance(typeof(FieldType), uiElement);
                }
            }

            return space;
        }
    }
}
