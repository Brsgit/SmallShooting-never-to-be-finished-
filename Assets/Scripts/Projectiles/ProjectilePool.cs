using System.Collections.Generic;
using UnityEngine;


namespace Projectile
{
    public class ProjectilePool : MonoBehaviour
    {
        [SerializeField] private ProjectileFactory _factory;
        [SerializeField] private ProjectileType _type;

        private const int POOL_SIZE = 64;
        private Queue<IShootable> _pool = new Queue<IShootable>();

        private Transform _transform;

        private void Start()
        {
            _transform = transform;

            for (int i = 0; i < POOL_SIZE; i++)
            {
                var projectile = _factory.Get(_type, _transform);
                _pool.Enqueue(projectile);
            }
        }

        public IShootable PrepareProjectile(Vector3 position)
        {
            var projectile = _pool.Dequeue();
            projectile.Activate(position);
            return projectile;
        }
    }
}
