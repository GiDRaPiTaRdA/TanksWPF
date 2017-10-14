using System;
using System.Linq;
using System.Linq.Expressions;
using System.Timers;
using Tanks.ActionModels;
using Tanks.Models;
using Tanks.Models.Units.Interfaces;
using Tanks.Models.Units.UnitModels;
using Tanks.Models.Units.UnitModels.BasicUnits;
using TraversalLib;

namespace Tanks.Manager.Action.Managers
{
    public class MotionManager : AbstractManagerBase
    {
        private CoordinatesManager CoordinatesManager { get; }

        public MotionManager(BattleField battleField) : base(battleField)
        {
            this.CoordinatesManager = new CoordinatesManager(this.BattleField.Size);
        }

        #region Move unit
        public bool CanMove(AbstractUnit unit, Coordinates targetCoords)
        {
            bool result =
                ActionManager.CanAct(unit, this.BattleField) &&
                  targetCoords != null &&
                !this.BattleField[targetCoords].Units.Any(f => f is ISolid);


            return result;
        }

        public bool CanMoveUp(AbstractUnit unit)
        {
            var result = this.CanMove(unit, this.CoordinatesManager.GetCoordinatesUp(unit.Coordinates));

            return result;
        }
        public bool CanMoveDown(AbstractUnit unit)
        {
            var result = this.CanMove(unit, this.CoordinatesManager.GetCoordinatesDown(unit.Coordinates));

            return result;
        }
        public bool CanMoveLeft(AbstractUnit unit)
        {
            var result = this.CanMove(unit, this.CoordinatesManager.GetCoordinatesLeft(unit.Coordinates));

            return result;
        }
        public bool CanMoveRight(AbstractUnit unit)
        {
            var result = this.CanMove(unit, this.CoordinatesManager.GetCoordinatesRight(unit.Coordinates));

            return result;
        }

        public bool Move(AbstractUnit unit, Dirrection dirrection, bool canMoveCheck = true)
        {
            Coordinates targetCoords = this.CoordinatesManager.GetCoordinates(unit.Coordinates, dirrection);

            var canMove = this.Move(unit, targetCoords, canMoveCheck);

            return canMove;
        }
        public bool Move(AbstractUnit unit, Coordinates targetCoords, bool canMoveCheck = true)
        {
            lock (this)
            {
                bool canMove = canMoveCheck ? this.CanMove(unit, targetCoords) : true;

                if (canMove)
                {
                    Coordinates prevoius = new Coordinates(unit.Coordinates);
                    unit.Coordinates = targetCoords;

                    if (unit.UnitPointState != null)
                    {
                        this.BattleField[prevoius].Pop(unit);
                        this.BattleField.PushField(unit);
                    }
                }

                return canMove;
            }
        }

        public bool MoveUp(AbstractUnit unit, bool canMoveCheck = true) => this.Move(unit, Dirrection.Forward, canMoveCheck);
        public bool MoveDown(AbstractUnit unit, bool canMoveCheck = true) => this.Move(unit, Dirrection.Backward, canMoveCheck);
        public bool MoveLeft(AbstractUnit unit, bool canMoveCheck = true) => this.Move(unit, Dirrection.Left, canMoveCheck);
        public bool MoveRight(AbstractUnit unit, bool canMoveCheck = true) => this.Move(unit, Dirrection.Right, canMoveCheck);
        #endregion


        #region Move ActionModel

        public bool CanMove(ActionModel model, AbstractUnit unit, Coordinates targetCoords)
        {
            bool result =
                ActionManager.CanAct(unit, this.BattleField) &&
                targetCoords != null &&
                (model.ModelMap.ModelUnits.Where<AbstractUnit>(f1 => f1.UnitPointState != null).Any(f => f.Coordinates.Equals(this.BattleField[targetCoords].Unit.Coordinates)) ||
                !(this.BattleField[targetCoords].Units.Any(f => f is ISolid)) || unit.UnitPointState == null);

            return result;
        }

        public bool CanMoveUp(ActionModel model)
        {
            bool result = model.ModelMap.ModelUnits.All<AbstractUnit>(f => this.CanMove(model, f, this.CoordinatesManager.GetCoordinatesUp(f.Coordinates)));

            return result;
        }
        public bool CanMoveDown(ActionModel model)
        {
            bool result = model.ModelMap.ModelUnits.All<AbstractUnit>(f => this.CanMove(model, f, this.CoordinatesManager.GetCoordinatesDown(f.Coordinates)));
            return result;
        }
        public bool CanMoveLeft(ActionModel model)
        {
            bool result = model.ModelMap.ModelUnits.All<AbstractUnit>(f => this.CanMove(model, f, this.CoordinatesManager.GetCoordinatesLeft(f.Coordinates)));
            return result;
        }
        public bool CanMoveRight(ActionModel model)
        {
            bool result = model.ModelMap.ModelUnits.All<AbstractUnit>(f => this.CanMove(model, f, this.CoordinatesManager.GetCoordinatesRight(f.Coordinates)));
            return result;
        }


        public bool Move(ActionModel model, Func<ActionModel, bool> canMoveFunc, Func<AbstractUnit, bool, bool> moveFunc)
        {
            bool canMove = canMoveFunc(model);

            if (canMove)
            {
                model.ModelMap.ModelUnits.ForEach<AbstractUnit>(f => moveFunc(f, false));
            }

            return canMove;
        }

        public bool MoveUp(ActionModel model) => this.Move(model, this.CanMoveUp, this.MoveUp);
        public bool MoveDown(ActionModel model) => this.Move(model, this.CanMoveDown, this.MoveDown);
        public bool MoveLeft(ActionModel model) => this.Move(model, this.CanMoveLeft, this.MoveLeft);
        public bool MoveRight(ActionModel model) => this.Move(model, this.CanMoveRight, this.MoveRight);

        #endregion

    }

    public class Motion
    {
        private readonly Timer timer;
        public Missle Missle { get; }
        Dirrection MotionDirrection { get; }
        Expression<Func<Dirrection>> ModelDirrection { get; }
        IMissleBehavior Behavior => this.Missle.MissleBehavior;
        public bool IsShot { get; private set; }

        private MotionManager MotionManager { get; }
        private DestructionManager DestructionManager { get; }
        private BattleField BattleField { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="missle"></param>
        /// <param name="motionDirrection"></param>
        /// <param name="modelDirrection"></param>
        /// <param name="motionManager"></param>
        /// <param name="destructionManager"></param>
        /// <param name="battleField"></param>
        /// <param name="frequancy"></param>
        public Motion(
            Missle missle,
            Dirrection motionDirrection,
            Expression<Func<Dirrection>> modelDirrection,
            MotionManager motionManager,
            DestructionManager destructionManager,
            BattleField battleField,
            int frequancy = 200)
        {
            // Properties
            this.Missle = missle;
            this.BattleField = battleField;
            this.MotionDirrection = motionDirrection;
            this.ModelDirrection = modelDirrection;

            // Managers
            this.MotionManager = motionManager;
            this.DestructionManager = destructionManager;

            // Timer
            this.timer = new Timer { Interval = frequancy };
            this.timer.Elapsed += this.TimerElapsed;

            // Events
            this.DestructionManager.OnDestroyUnit += this.OnDestroy;
        }

        private void OnDestroy(object sender, EventArgs e)
        {
            if (sender == this.Missle.Unit)
            {
                this.Stop();
            }
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            this.Action();
        }

        private void Action()
        {
            lock (this)
            {
                if (!this.IsShot)
                {
                    this.Behavior.Fire(
                        this.Missle.Unit,
                        this.MotionDirrection,
                        this.ModelDirrection,
                        this.MotionManager,
                        this.DestructionManager,
                        this.BattleField,
                        this.Stop);
                    this.IsShot = true;
                }
                else
                {
                    this.Behavior.Collide(
                        this.Missle.Unit,
                        this.MotionDirrection,
                        this.ModelDirrection,
                        this.MotionManager,
                        this.DestructionManager,
                        this.BattleField,
                        this.Stop);
                }
            }
        }

        public void Start()
        {
            this.timer.Start();
            this.BattleField.Motions.Add(this);

            this.Action();
        }

        public void Stop()
        {
            this.timer.Stop();
            this.BattleField.Motions.Remove(this);
        }
    }
}
