using System.Collections.Generic;
using UnityEngine;


namespace Projectile
{
    public class ProjectilesPool : MonoBehaviour
    {
        [SerializeField] private ProjectileFactory _factory;
        [SerializeField] private ProjectileType _type;

        private const int POOL_SIZE = 128;
        private Queue<IPoolable> _pool = new Queue<IPoolable>();

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

        public IPoolable GetItemFromQ()
        {
            var projectile = _pool.Dequeue();
            projectile.Activate();
            return projectile;
        }
    }
}