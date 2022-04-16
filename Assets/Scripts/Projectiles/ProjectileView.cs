using UnityEngine;

namespace Projectile
{
    // Class for animations
    public abstract class ProjectileView : MonoBehaviour
    {
        protected Projectile _projectile;

        public virtual void Initialize(Projectile projectile)
        {
            _projectile = projectile;
        }

    }
}