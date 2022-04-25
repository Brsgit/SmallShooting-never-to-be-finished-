using Projectile;
using UnityEngine;

namespace Core
{
    public class ReadyToShootState : State
    {
        public ReadyToShootState(PlayerController controller) : base(controller) { }

        public override void Shoot(Vector3 destination)
        {
            IShootable projectile = PlayerController.Pool.PrepareProjectile(PlayerController.transform.position);
            projectile.Shoot(destination);
        }
    }

}
