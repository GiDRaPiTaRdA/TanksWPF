using Tanks.Models;

namespace Tanks.Manager.Action.Managers
{
    public abstract class AbstractManagerBase
    {
        protected BattleField BattleField { get; }

        public AbstractManagerBase(BattleField battleField)
        {
            this.BattleField = battleField;
        }
    }
}