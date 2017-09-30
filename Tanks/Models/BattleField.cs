using System.Collections.Generic;
using Tanks.ActionModels;
using Tanks.Models.Fields;
using Tanks.Models.Fields.FieldTypes;
using TraversalLib;

namespace Tanks.Models
{
    public class BattleField
    {
        public Coordinates Size { get; }

        public FieldSlot[,] SpotsMatrix { get; private set; }

        public Dictionary<int, ActionModel> Models { get; private set; }

        public BattleField(int x, int y)
        {
            this.Size = new Coordinates(x, y);

            this.Initialize();
        }

        private void Initialize()
        {
            this.Models = new Dictionary<int, ActionModel>();

            this.SpotsMatrix = new FieldSlot[this.Size.X, this.Size.Y];

            this.SpotsMatrix.Traversal((o, ps) => this[ps[0], ps[1]] = new FieldSlot(new EmptyField(ps[0], ps[1])));
        }

        #region Field operations
        public void PushField(AbstractField field)
        {
            if (field.FieldPointState!=null)
            {
                this[field.Coordinates].Push(field);
            }
        }
        public void PopField(AbstractField field)
        {
            if (field.FieldPointState != null)
            {
                this[field.Coordinates].Pop(field);
            }
        }

        public void SetMap(ModelMap map)
        {
            map.ModelFields.Traversal((o, ps) => this.PushField((AbstractField)o));
        }
        #endregion

        #region Model operations
        public void PushModel(ActionModel model)
        {
            this.Models.Add(model.GetHashCode(), model);
            model.ModelMap.ModelFields.ForEach<AbstractField>(this.PushField);
        }
        public void PopModel(ActionModel model)
        {
            this.Models.Remove(model.GetHashCode());
            model.ModelMap.ModelFields.ForEach<AbstractField>(this.PopField);
        }
        #endregion

        #region Indexators
        public FieldSlot this[Coordinates coordinates]
        {
            get
            {
                FieldSlot slot = this[coordinates.X, coordinates.Y];
                return slot;
            }
            private set
            {
                this[coordinates.X, coordinates.Y] = value;
            }

        }

        public FieldSlot this[int x, int y]
        {
            get
            {
                FieldSlot slot = this.SpotsMatrix[x, y];
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
