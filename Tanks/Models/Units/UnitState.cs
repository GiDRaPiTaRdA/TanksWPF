namespace Tanks.Models.Units
{
    /// <summary>
    /// State Must be the name of target type unit
    /// </summary>
    public enum UnitState
    {
        EmptyUnit,
        Tank,
        TankEnemy,
        Grass,
        Wall,

        DefaultCannon,
        CannonBall,

        RemoteContolledCannon,
        RemoteContolledMissle,

        BrickCannon,
        Brick,

        RemoteControlledBrickCannon,
        RemoteControlledBrickMissle

    }
}
