using System;
using Tanks.ActionModels;
using Tanks.Manager.Action;
using Tanks.Manager.Action.Managers;
using Tanks.Models.Units.Interfaces;
using Tanks.Models.Units.UnitModels.MissleBehaviors;

namespace Tanks.Models.Units.UnitModels.BasicUnits
{
    //public abstract class Missle : Solid, IMissle
    //{
    //    public IMissleBehavior MissleBehavior { get; set; }

    //    public Missle() { }
    //    public Missle(IMissleBehavior behavoir) 
    //    {
    //        this.MissleBehavior = behavoir;
    //    }
    //    public Missle(Coordinates coordinates) : this(coordinates, new BrickBehavior()) { }
    //    public Missle(Coordinates coordinates, IMissleBehavior behavoir) : base(coordinates)
    //    {
    //        this.MissleBehavior = behavoir;
    //    }

       
    //}

    public class Missle : IMissle
    {
        public IMissleBehavior MissleBehavior { get; set; }
        public AbstractUnit Unit { get; }

        public Missle(AbstractUnit solidUnit, IMissleBehavior behavoir)
        {
            this.Unit = solidUnit;
            this.MissleBehavior = behavoir;
        }
    }
}