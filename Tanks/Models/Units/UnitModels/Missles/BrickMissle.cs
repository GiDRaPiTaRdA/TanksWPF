﻿using System;
using System.Threading;
using Tanks.ActionModels;
using Tanks.Manager.Action;
using Tanks.Manager.Action.Managers;
using Tanks.Models.Units.Interfaces;
using Tanks.Models.Units.UnitModels.BasicUnits;
using Tanks.Models.Units.UnitModels.MissleBehaviors;

namespace Tanks.Models.Units.UnitModels.Missles
{
    [UnitState(UnitState.BrickMissle)]
    public class BrickMissle : Missle
    {
        public BrickMissle(){}
        public BrickMissle(Coordinates coordinates) : base(coordinates, new BrickBehavior())
        {
            this.MissleBehavior = new MissleBehavior();
        }
    }
}