using System;
using Tanks.ActionModels;
using Tanks.Manager.Action;
using Tanks.Manager.Action.Managers;

namespace Tanks.Models.Units.Interfaces
{
    public interface IMissle
    {
        IMissleBehavior MissleBehavior { get; }
    }
}