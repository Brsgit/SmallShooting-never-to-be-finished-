using UnityEngine;

namespace Projectile
{
    [CreateAssetMenu]
    public class ProjectileFactory : GameObjectFactory
    {


        [SerializeField] private ProjectileConfig _bullet, _bigBullet;

        public Projectile Get(ProjectileType type, Transform transform)
        {
            var config = GetConfig(type);
            Projectile instance = CreateGameObjectInstance(config.Prefab, transform);
            instance.OrigingFactory = this;
            instance.Initialize(config.Scale, config.Damage, config.Speed, config.LifeTime);
            Reclaim(instance);
            return instance;
        }

        private ProjectileConfig GetConfig(ProjectileType type)
        {
            return type switch
            {
                ProjectileType.Bullet => _bullet,
                ProjectileType.BitBullet => _bigBullet,
                _ => _bullet,
            };
        }

        public void Reclaim(Projectile projectile)
        {
            projectile.gameObject.SetActive(false);
        }
    }
}
