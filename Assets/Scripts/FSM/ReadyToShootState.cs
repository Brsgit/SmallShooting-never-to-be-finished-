using Projectile;
using UnityEngine;

public class ReadyToShootState : State
{
    public ReadyToShootState(PlayerController controller) : base(controller) { }

    public override void Start()
    {
        base.Start();
    }

    public override void Shoot(Vector3 destination)
    {
        IShootable projectile = PlayerController.Pool.GetItemFromQ();
        projectile.Shoot(destination);
    }
}
