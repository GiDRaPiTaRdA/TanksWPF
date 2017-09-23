using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Models.Fields;
using TraversalLib;

namespace Tanks.Manager
{
    static class FieldRotation
    {
        public static AbstractField[,] Rotate(this AbstractField[,] array, Func<AbstractField[,], AbstractField[,]> rotate)
        {
            var rotatedArray = rotate(array);

            //Create array
            Coordinates[,] coords = new Coordinates[array.GetLength(0), array.GetLength(1)];

            // Clone coords
            array.Traversal((o, ps) => coords[ps[0], ps[1]] = new Coordinates(array[ps[0], ps[1]].Coordinates));

            // Paste coords
            coords.Traversal((o, ps) => rotatedArray[((Coordinates)o).X, ((Coordinates)o).Y].Coordinates = (Coordinates)o);

            return rotatedArray;
        }

        public static AbstractField[,] RotateWithNull(this AbstractField[,] array, Func<AbstractField[,], AbstractField[,]> rotate)
        {
            var rotatedArray = rotate(array);

            //Create array
            Coordinates[,] coords = new Coordinates[array.GetLength(0), array.GetLength(1)];

            // Clone coords
            array.Traversal((o, ps) => coords[ps[0], ps[1]] = new Coordinates(array[ps[0], ps[1]].Coordinates));

            // Paste coords
            coords.Traversal((o, ps) => rotatedArray[((Coordinates)o).X, ((Coordinates)o).Y].Coordinates = (Coordinates)o);

            return rotatedArray;
        }
    }
}
