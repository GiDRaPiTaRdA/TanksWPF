using System;
using System.Windows;
using System.Windows.Controls;

namespace Tanks.View.UserInterface
{
    class UiManager
    {
        public int ControlSize { get; }

        public UiManager(int controlSize = 25)
        {
            this.ControlSize = controlSize;
        }

        public T[,] CreateMatrix<T>(int x, int y, Grid parrent, Action<Control> modify = null) where T : Control
        {
            T[,] space = new T[x, y];

            // Add columns X
            for (int i = 0; i < x; i++)
            {
                ColumnDefinition columnDef = new ColumnDefinition {Width = new GridLength(this.ControlSize)};
                parrent.ColumnDefinitions.Add(columnDef);
            }

            // Add rows Y
            for (int i = 0; i < y; i++)
            {
                RowDefinition rowDef = new RowDefinition {Height = new GridLength(this.ControlSize)};
                parrent.RowDefinitions.Add(rowDef);
            }

            // Add to UI Elements to Parrent
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    T uiElement = (T)Activator.CreateInstance(typeof(T));

                    modify?.Invoke(uiElement);

                    Grid.SetColumn(uiElement, i);
                    Grid.SetRow(uiElement, j);
                    parrent.Children.Add(uiElement);

                    // Assign unit
                    space[i, j] = uiElement;
                }
            }

            return space;
        }

        //public AbstractUnit[,] CreateMatrix<T, FieldType>(int x, int y, Grid parrent, Action<Control> modify = null) where T : Control where FieldType : AbstractUnit
        //{
        //    AbstractUnit[,] space = new AbstractUnit[x, y];

        //    // Add columns X
        //    for (int i = 0; i < x; i++)
        //    {
        //        ColumnDefinition columnDef = new ColumnDefinition();
        //        columnDef.Width = new GridLength(ControlSize);
        //        parrent.ColumnDefinitions.Add(columnDef);
        //    }

        //    // Add rows Y
        //    for (int i = 0; i < y; i++)
        //    {
        //        RowDefinition rowDef = new RowDefinition();
        //        rowDef.Height = new GridLength(ControlSize);
        //        parrent.RowDefinitions.Add(rowDef);
        //    }

        //    // Add to UI Elements to Parrent
        //    for (int i = 0; i < x; i++)
        //    {
        //        for (int j = 0; j < y; j++)
        //        {
        //            Control uiElement = (T)Activator.CreateInstance(typeof(T));

        //            modify?.Invoke(uiElement);

        //            Grid.SetColumn(uiElement, i);
        //            Grid.SetRow(uiElement, j);
        //            parrent.Children.Add(uiElement);

        //            // Assign unit
        //            space[i, j] = (FieldType)Activator.CreateInstance(typeof(FieldType),i,j,uiElement);
        //        }
        //    }

        //    return space;
        //}

        //public AbstractUnit[,] CreateMatrix<T, FieldType>(AbstractUnit[,] space, Grid parrent, Action<Control> modify = null) where T : Control where FieldType : AbstractUnit
        //{
        //    int x = space.GetLength(0);
        //    int y = space.GetLength(1);

        //    // Add columns X
        //    for (int i = 0; i < x; i++)
        //    {
        //        ColumnDefinition columnDef = new ColumnDefinition();
        //        columnDef.Width = new GridLength(ControlSize);
        //        parrent.ColumnDefinitions.Add(columnDef);
        //    }

        //    // Add rows Y
        //    for (int i = 0; i < y; i++)
        //    {
        //        RowDefinition rowDef = new RowDefinition();
        //        rowDef.Height = new GridLength(ControlSize);
        //        parrent.RowDefinitions.Add(rowDef);
        //    }

        //    // Add to UI Elements to Parrent
        //    for (int i = 0; i < x; i++)
        //    {
        //        for (int j = 0; j < y; j++)
        //        {
        //            Control uiElement = (T)Activator.CreateInstance(typeof(T));

        //            modify(uiElement);

        //            Grid.SetColumn(uiElement, i);
        //            Grid.SetRow(uiElement, j);
        //            parrent.Children.Add(uiElement);

        //            // Assign unit
        //            space[i, j] = (FieldType)Activator.CreateInstance(typeof(FieldType),i,j, uiElement);
        //        }
        //    }

        //    return space;
        //}

        public static T[,] ModifyMatrix<T>(T[,] space, Action<Control> modify = null) where T : Control
        {
            // Add to UI Elements to Parrent
            for (int i = 0; i < space.GetLength(0); i++)
            {
                for (int j = 0; j < space.GetLength(1); j++)
                {
                    modify?.Invoke(space[i, j]);
                }
            }

            return space;
        }
    }
}
