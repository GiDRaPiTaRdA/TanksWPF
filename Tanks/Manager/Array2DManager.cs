﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tanks.ActionModels;
using Tanks.Models.Fields;
using TraversalLib;

namespace Tanks.Manager
{
    class Array2DManager
    {
        public static T[,] RotateRight<T>(T[,] array)
        {
            T[,] newMatrix = new T[array.GetLength(1), array.GetLength(0)];
            int newColumn, newRow = 0;
            for (int oldColumn = array.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
            {
                newColumn = 0;
                for (int oldRow = 0; oldRow < array.GetLength(0); oldRow++)
                {
                    newMatrix[newRow, newColumn] = array[oldRow, oldColumn];
                    newColumn++;
                }
                newRow++;
            }
            return newMatrix;
        }

        public static T[,] RotateLeft<T>(T[,] array)
        {
            T[,] newMatrix = new T[array.GetLength(1), array.GetLength(0)];
            int newColumn = array.GetLength(0)-1;
            int newRow = 0;
            for (int oldColumn = 0; oldColumn< array.GetLength(1); oldColumn++)
            {
                newColumn = array.GetLength(0) -1;
                for (int oldRow = 0; oldRow < array.GetLength(0); oldRow++)
                {
                    newMatrix[newRow, newColumn] = array[oldRow, oldColumn];
                    newColumn--;
                }
                newRow++;
            }
            return newMatrix;
        }

        public static T[,] MirrorHorisontal<T>(T[,] array)
        {
            T[,] newMatrix = new T[array.GetLength(0), array.GetLength(1)];
            int newColumn = array.GetLength(0) - 1;
            int newRow = 0;
            for (int oldColumn = 0; oldColumn < array.GetLength(1); oldColumn++)
            {
                newColumn = array.GetLength(0) - 1;
                for (int oldRow = 0; oldRow < array.GetLength(0); oldRow++)
                {
                    newMatrix[newColumn, newRow] = array[oldRow, oldColumn];
                    newColumn--;
                }
                newRow++;
            }
            return newMatrix;
        }

        public static T[,] MirrorVertical<T>(T[,] array)
        {
            T[,] newMatrix = new T[array.GetLength(0), array.GetLength(1)];
            int newColumn = 0;
            int newRow = array.GetLength(1) - 1;
            for (int oldColumn = 0; oldColumn < array.GetLength(1); oldColumn++)
            {
                newColumn = 0;
                for (int oldRow = 0; oldRow < array.GetLength(0); oldRow++)
                {
                    newMatrix[newColumn, newRow] = array[oldRow, oldColumn];
                    newColumn++;
                }
                newRow--;
            }
            return newMatrix;
        }
    }


    static class Array2DManagerSpecial
    {
        public static AbstractField[,] Rotate(this AbstractField[,] array, Func<AbstractField[,], AbstractField[,]> rotate)
        {
            var rotatedArray = rotate(array);

            //Create array
            Coordinates[,] coords = new Coordinates [array.GetLength(0), array.GetLength(1)];

            // Clone coords
            array.Traversal((o,ps)=> coords[ps[0],ps[1]]=new Coordinates(array[ps[0],ps[1]].Coordinates));

            // Paste coords
            coords.Traversal((o, ps) => rotatedArray[((Coordinates)o).X, ((Coordinates)o).Y].Coordinates = (Coordinates)o);

            return rotatedArray;
        }

        //public static T[,] RotateLeft<T>(T[,] array)
        //{
        //    T[,] newMatrix = new T[array.GetLength(1), array.GetLength(0)];
        //    int newColumn = array.GetLength(0) - 1;
        //    int newRow = 0;
        //    for (int oldColumn = 0; oldColumn < array.GetLength(1); oldColumn++)
        //    {
        //        newColumn = array.GetLength(0) - 1;
        //        for (int oldRow = 0; oldRow < array.GetLength(0); oldRow++)
        //        {
        //            newMatrix[newRow, newColumn] = array[oldRow, oldColumn];
        //            newColumn--;
        //        }
        //        newRow++;
        //    }
        //    return newMatrix;
        //}

        //public static T[,] MirrorHorisontal<T>(T[,] array)
        //{
        //    T[,] newMatrix = new T[array.GetLength(0), array.GetLength(1)];
        //    int newColumn = array.GetLength(0) - 1;
        //    int newRow = 0;
        //    for (int oldColumn = 0; oldColumn < array.GetLength(1); oldColumn++)
        //    {
        //        newColumn = array.GetLength(0) - 1;
        //        for (int oldRow = 0; oldRow < array.GetLength(0); oldRow++)
        //        {
        //            newMatrix[newColumn, newRow] = array[oldRow, oldColumn];
        //            newColumn--;
        //        }
        //        newRow++;
        //    }
        //    return newMatrix;
        //}

        //public static T[,] MirrorVertical<T>(T[,] array)
        //{
        //    T[,] newMatrix = new T[array.GetLength(0), array.GetLength(1)];
        //    int newColumn = 0;
        //    int newRow = array.GetLength(1) - 1;
        //    for (int oldColumn = 0; oldColumn < array.GetLength(1); oldColumn++)
        //    {
        //        newColumn = 0;
        //        for (int oldRow = 0; oldRow < array.GetLength(0); oldRow++)
        //        {
        //            newMatrix[newColumn, newRow] = array[oldRow, oldColumn];
        //            newColumn++;
        //        }
        //        newRow--;
        //    }
        //    return newMatrix;
        //}


    }

}