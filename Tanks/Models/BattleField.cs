using System.Collections.Generic;
using Tanks.ActionModels;
using Tanks.Manager.Action.Managers;
using Tanks.Models.Units.UnitModels;
using TraversalLib;

namespace Tanks.Models
{
    public class BattleField
    {
        public Coordinates Size { get; }

        public UnitSlot[,] SpotsMatrix { get; private set; }

        public Dictionary<int, ActionModel> Models { get; private set; }

        public List<Motion> Motions { get; private set; }

        public BattleField(int x, int y)
        {
            this.Size = new Coordinates(x, y);

            this.Initialize();
        }

        private void Initialize()
        {
            this.Models = new Dictionary<int, ActionModel>();

            this.Motions =  new List<Motion>();

            this.SpotsMatrix = new UnitSlot[this.Size.X, this.Size.Y];

            this.SpotsMatrix.Traversal((o, ps) => this[ps[0], ps[1]] = new UnitSlot(new EmptyUnit(ps[0], ps[1])));
        }

        #region Unit operations
        public void PushField(AbstractUnit unit)
        {
            if (
                unit.UnitPointState!=null &&
                unit.Coordinates!=null
                )
            {
                this[unit.Coordinates].Push(unit);
            }
        }
        public void PopField(AbstractUnit unit)
        {
            if (unit.UnitPointState != null)
            {
                this[unit.Coordinates].Pop(unit);
            }
        }

        public void SetMap(ModelMap map)
        {
            map.ModelUnits.Traversal((o, ps) => this.PushField((AbstractUnit)o));
        }
        #endregion

        #region Model operations
        public void PushModel(ActionModel model)
        {
            this.Models.Add(model.GetHashCode(), model);
            model.ModelMap.ModelUnits.ForEach<AbstractUnit>(this.PushField);
        }
        public void PopModel(ActionModel model)
        {
            this.Models.Remove(model.GetHashCode());
            model.ModelMap.ModelUnits.ForEach<AbstractUnit>(this.PopField);
        }
        #endregion

        #region Indexators
        public UnitSlot this[Coordinates coordinates]
        {
            get
            {
                UnitSlot slot = this[coordinates.X, coordinates.Y];
                return slot;
            }
            private set
            {
                this[coordinates.X, coordinates.Y] = value;
            }

        }

        public UnitSlot this[int x, int y]
        {
            get
            {
                UnitSlot slot = this.SpotsMatrix[x, y];
                return slot;
            }
            private set
            {
                this.SpotsMatrix[x, y] = value;
            }

        }
        #endregion
    }
}
